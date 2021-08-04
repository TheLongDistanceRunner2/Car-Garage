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
    public class PartsModelsController : Controller
    {
        private GarageContex db = new GarageContex();

        // GET: PartsModels
        public ActionResult Index()
        {
            var part = db.Part.Include(p => p.Car);
            return View(part.ToList());
        }
        public ActionResult Wszystkieczesci()
        {
            var part = db.Part.Include(p => p.Car);
            return View(part.ToList());
        }

        // GET: PartsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.Part.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // GET: PartsModels/Create
        public ActionResult Create()
        {
            string UserEmail = User.Identity.GetUserName();

            OwnerModels owner = db.Owner.Single(a => a.Email == UserEmail);
            List<CarModels> Car = db.Car.Where(a => a.OwnerID == owner.ID).ToList();
            ViewBag.CarId = new SelectList(Car, "ID", "Make");

            //ViewBag.CarId = new SelectList(db.Car, "ID", "Make");
            return View();
        }

        // POST: PartsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarId,Name,CatalogNo,PurchaseAmount,SalesAmount,PurchaseDate,SalesDate")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                db.Part.Add(partsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Car, "ID", "Make", partsModels.CarId);
            return View(partsModels);
        }

        // GET: PartsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.Part.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Car, "ID", "Make", partsModels.CarId);
            return View(partsModels);
        }

        // POST: PartsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarId,Name,CatalogNo,PurchaseAmount,SalesAmount,PurchaseDate,SalesDate")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Car, "ID", "Make", partsModels.CarId);
            return View(partsModels);
        }

        // GET: PartsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.Part.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // POST: PartsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartsModels partsModels = db.Part.Find(id);
            db.Part.Remove(partsModels);
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
