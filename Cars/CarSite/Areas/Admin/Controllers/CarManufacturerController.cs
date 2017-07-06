using CarSite.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CarSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarManufacturerController : Controller
    {
        CarContext _carContext;

        public CarManufacturerController()
        {
            _carContext = new CarContext();
        }
        // GET: Admin/CarManufacturer
        public ActionResult Index()
        {
            var carManufacturer = _carContext.CarManufacturers.ToList();
            return View(carManufacturer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarManufacturer carManufacturer)
        {
            if (ModelState.IsValid)
            {
                _carContext.CarManufacturers.Add(carManufacturer);
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carManufacturer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarManufacturer carManufacturer = _carContext.CarManufacturers.Find(id);
            if (carManufacturer == null)
            {
                return HttpNotFound();
            }
            return View(carManufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarManufacturer carManufacturer)
        {
            if (ModelState.IsValid)
            {
                _carContext.Entry(carManufacturer).State = EntityState.Modified;
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carManufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _carContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}