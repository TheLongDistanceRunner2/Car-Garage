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
    public class AdvertismentModelsController : Controller
    {
        private GarageContex db = new GarageContex();

        // GET: AdvertismentModels
        public ActionResult Index()
        {
            //var message = 

            var advertisment = db.Advertisment.Include(a => a.Car);
            return View(advertisment.ToList());

        }


        public ActionResult MojeOgloszenia()
        {
            var advertisment = db.Advertisment.Include(a => a.Car);
            return View(advertisment.ToList());
        }
        // GET: AdvertismentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertismentModels advertismentModels = db.Advertisment.Find(id);
            if (advertismentModels == null)
            {
                return HttpNotFound();
            }
            return View(advertismentModels);
        }

        // GET: AdvertismentModels/Create
        public ActionResult Create()
        {
            // pobieramy maila:
            string userEmail = User.Identity.GetUserName();
            // to zwraca nam właściciela, którego mail jest równy mailowi zalogowanego usera:
            OwnerModels owner = db.Owner.Single(a => a.Email == userEmail);
            // przypisujemy ID zalogowanego ownera:
            int ownerId = owner.ID;

            // tworzymy liste Samochodów, które należą do tego właściciela:
            List<CarModels> cars = db.Car.Where(c => c.OwnerID == ownerId)/*.Where(c => c.isActive == false)*/.ToList();
            // wrzucamy do CarId liste tych samochodów:
            ViewBag.CarId = new SelectList(cars, "ID", "Make");

            // ==========================================================
            // tu pobranie tylko tej nazwy danego auta:
            //string model = 
            //List<CarModels> cars2 = db.Car.Where(c => c.OwnerID == ownerId).Where(c => c.Model == model).ToList();
            ViewBag.CarModel = new SelectList(cars, "ID", "Model"); // MATI - TA LINIJKA CHYBA NIE JEST KONIECZNA !!??

            return View();
        }

        // POST: AdvertismentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarId,Active,SalesDate,SalesAmount")] AdvertismentModels advertismentModels)
        {
            if (ModelState.IsValid)
            {
                // sprawdzamy czy dane auto zostało dodane- czy liczba wystapien tego auta jest rozna od 0
                // (jeśli tak, to wyświetlamy stosowny komunikat):
                var inDatabase = db.Advertisment.SqlQuery("SELECT * FROM dbo.AdvertismentModels WHERE dbo.AdvertismentModels.CarID = " + advertismentModels.CarId).Count(); 
                if (inDatabase > 0)
                {
                    return RedirectToAction("Index", "WrongCar");
                }

                db.Advertisment.Add(advertismentModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string userEmail = User.Identity.GetUserName();
            OwnerModels owner = db.Owner.Single(a => a.Email == userEmail);
            int ownerId = owner.ID;
            List<CarModels> cars = db.Car.Where(c => c.OwnerID == ownerId)/*.Where(c => c.isActive == false)*/.ToList();

            ViewBag.CarId = new SelectList(cars, "ID", "Make", advertismentModels.CarId);


            return View(advertismentModels);
        }

        // GET: AdvertismentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertismentModels advertismentModels = db.Advertisment.Find(id);
            if (advertismentModels == null)
            {
                return HttpNotFound();
            }
            string userEmail = User.Identity.GetUserName();
            OwnerModels owner = db.Owner.Single(a => a.Email == userEmail);
            int ownerId = owner.ID;
            List<CarModels> cars = db.Car.Where(c => c.OwnerID == ownerId).ToList();

            ViewBag.CarId = new SelectList(cars, "ID", "Make", advertismentModels.CarId);
            return View(advertismentModels);
        }

        // POST: AdvertismentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarId,Active,SalesDate,SalesAmount")] AdvertismentModels advertismentModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertismentModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string userEmail = User.Identity.GetUserName();
            OwnerModels owner = db.Owner.Single(a => a.Email == userEmail);
            int ownerId = owner.ID;
            List<CarModels> cars = db.Car.Where(c => c.OwnerID == ownerId).ToList();

            ViewBag.CarId = new SelectList(cars, "ID", "Make", advertismentModels.CarId);
            return View(advertismentModels);
        }

        // GET: AdvertismentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertismentModels advertismentModels = db.Advertisment.Find(id);
            if (advertismentModels == null)
            {
                return HttpNotFound();
            }
            return View(advertismentModels);
        }

        // POST: AdvertismentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvertismentModels advertismentModels = db.Advertisment.Find(id);
            db.Advertisment.Remove(advertismentModels);
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
