using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassicGarage.DAL;
using ClassicGarage.Models;
using Microsoft.AspNet.Identity;

namespace ClassicGarage.Controllers
{
    public class CarModelsController : Controller
    {
        private GarageContex db = new GarageContex();

        // GET: CarModels
        public ActionResult Index()
        {
            var car = db.Car.Include(c => c.Owner);
            return View(car.ToList());
        }
        public ActionResult MojeSamochody()
        {
            var car = db.Car.Include(c => c.Owner);
            return View(car.ToList());
        }



        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }
        public ActionResult Naprawy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }
        public ActionResult Czesci(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Make,Model,Year,VIN,Name,Picture,PurchaseDate,PurchaseAmount,SalesDate,SalesAmount,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                string email = User.Identity.GetUserName();
                OwnerModels owner = db.Owner.Single(o => o.Email == email);
                carModels.OwnerID = owner.ID;
                db.Car.Add(carModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(carModels);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }

            return View(carModels);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Make,Model,Year,VIN,Name,Picture,PurchaseDate,PurchaseAmount,SalesDate,SalesAmount,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                string email = User.Identity.GetUserName();
                OwnerModels owner = db.Owner.Single(o => o.Email == email);
                carModels.OwnerID = owner.ID;
                db.Entry(carModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carModels);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModels carModels = db.Car.Find(id);
            db.Car.Remove(carModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
