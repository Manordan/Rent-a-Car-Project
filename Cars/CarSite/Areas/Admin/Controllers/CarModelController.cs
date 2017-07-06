using CarSite.Models;
using CarSite.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace CarSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarModelController : Controller
    {
        CarContext _carContext;

        public CarModelController()
        {
            _carContext = new CarContext();
        }
        // GET: Admin/CarModel
        public ActionResult Index()
        {
           var carModels= _carContext.CarModels.Include(c => c.CarManufacturer).ToList();
            return View(carModels);
        }

        public ActionResult Create()
        {
            var carManufacturers = _carContext.CarManufacturers.ToList();
            CarModelViewModel carModelsViewModel = new CarModelViewModel
            {
                
                CarManufacturers = carManufacturers
            };
            return View(carModelsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModelViewModel carModelViewModel)
        {
            if (ModelState.IsValid)
            {
                _carContext.CarModels.Add(carModelViewModel.CarModel);
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carModelViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carModel = _carContext.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }

            var carManufacturers = _carContext.CarManufacturers.ToList();

            CarModelViewModel carModelsViewModel = new CarModelViewModel
            {
                CarModel= carModel,
                CarManufacturers = carManufacturers
            };

            return View(carModelsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarModelViewModel carModelViewModel)
        {
            if (ModelState.IsValid)
            {
                CarModel carModel = new CarModel();
                carModel = carModelViewModel.CarModel;

                _carContext.Entry(carModel).State = EntityState.Modified;
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carModelViewModel);
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