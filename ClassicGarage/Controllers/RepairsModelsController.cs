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
    public class RepairsModelsController : Controller
    {
        private GarageContex db = new GarageContex();

        // GET: RepairsModels
        public ActionResult Index()
        {
            var repair = db.Repair.Include(r => r.Car);
            return View(repair.ToList());
        }

        // GET: RepairsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.Repair.Find(id);
            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            return View(repairsModels);
        }

        // GET: RepairsModels/Create
        public ActionResult Create()
        {
            string UserEmail = User.Identity.GetUserName();

            OwnerModels owner = db.Owner.Single(a => a.Email == UserEmail);
            List<CarModels> Car = db.Car.Where(a => a.OwnerID == owner.ID).ToList();
            ViewBag.CarId = new SelectList(Car, "ID", "Make");
            return View();
        }

        // POST: RepairsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarId,Name,Description,RepairPrice")] RepairsModels repairsModels)
        {
            if (ModelState.IsValid)
            {
                db.Repair.Add(repairsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string UserEmail = User.Identity.GetUserName();

            OwnerModels owner = db.Owner.Single(a => a.Email == UserEmail);
            List<CarModels> Car = db.Car.Where(a => a.OwnerID == owner.ID).ToList();
            ViewBag.CarId = new SelectList(Car, "ID", "Make", repairsModels.CarId);
            return View(repairsModels);
        }

        // GET: RepairsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.Repair.Find(id);
            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            string UserEmail = User.Identity.GetUserName();

            OwnerModels owner = db.Owner.Single(a => a.Email == UserEmail);
            List<CarModels> Car = db.Car.Where(a => a.OwnerID == owner.ID).ToList();
            ViewBag.CarId = new SelectList(Car, "ID", "Make", repairsModels.CarId);

            return View(repairsModels);
        }

        // POST: RepairsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarId,Name,Description,RepairPrice")] RepairsModels repairsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string UserEmail = User.Identity.GetUserName();

            OwnerModels owner = db.Owner.Single(a => a.Email == UserEmail);
            List<CarModels> Car = db.Car.Where(a => a.OwnerID == owner.ID).ToList();
            ViewBag.CarId = new SelectList(Car, "ID", "Make", repairsModels.CarId);
            return View(repairsModels);
        }

        // GET: RepairsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.Repair.Find(id);
            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            return View(repairsModels);
        }

        // POST: RepairsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairsModels repairsModels = db.Repair.Find(id);
            db.Repair.Remove(repairsModels);
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
