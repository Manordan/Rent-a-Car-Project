using CarSite.Models;
using CarSite.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;


namespace CarSite.Controllers
{
    public class CarsController : Controller
    {
        CarContext _carContext;
        public CarsController()
        {
            _carContext = new CarContext();
          
        }
        // GET: Cars

        public ActionResult Index(int? carManufacturer, int? carModel, int? transmission, DateTime startdate, DateTime enddate)
        {
            try
            {
                ViewBag.startdate = startdate;
                ViewBag.enddate = enddate;



                var car = _carContext.Cars.AsQueryable();
                car = car.Where(x => x.IsRightForRent && x.IsRightForRent);

                if (carManufacturer != null)
                {
                    car = car.Where(c => c.CarModel.CarManufacturerId == carManufacturer.Value);

                }

                if (carModel != null)
                {
                    car = car.Where(c => c.CarModelId == carModel.Value);

                }

                if (transmission != null)
                {
                    car = car.Where(c => c.Transmission == transmission.Value);

                }

                if (startdate != null)
                {
                    car = car.Where(c => !c.Rents.Any(r =>
                        (startdate >= r.StartDate && startdate <= r.EndtDate)
                        ||
                        (enddate <= r.EndtDate && enddate >= r.StartDate)
                        ));
                }


                var carList = car.Select(c => new CarsViewModel
                {
                    Id = c.Id,
                    Transmission = c.Transmission,
                    Picture = c.Picture,
                    CarManufacturer = c.CarModel.CarManufacturer.Name,
                    Model = c.CarModel.Model,
                    DailyCost = c.CarModel.DailyCost

                }).ToList();





                return View(carList);
            }
            catch (Exception)
            {

                return RedirectToAction("NotFounf", "Error");
            }
        }


     


        [HttpPost]
        public ActionResult Details(int? id, DateTime sdate, DateTime edate)
        {

            var order = _carContext.Cars.Where(c => c.Id == id).Select(c => new OrderViewModel
            {
                Id = c.Id,
                Transmission = c.Transmission,
                Picture = c.Picture,
                CarManufacturer = c.CarModel.CarManufacturer.Name,
                Model = c.CarModel.Model,
                DailyCost = c.CarModel.DailyCost,
                StartDate = sdate,
                EndDate = edate,

            }).FirstOrDefault();

            Session["Order"] = order;


            return View(order);
        }
        [Authorize(Roles = "User")]
        public ActionResult Order()
        {
            if (Session["Order"] == null)
            {
                return HttpNotFound();
            }

            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel = (OrderViewModel)Session["Order"];
            Session.Remove("Order");
           
            Rent rent = new Rent
            {
                CarId = orderViewModel.Id,
                StartDate = orderViewModel.StartDate,
                EndtDate = orderViewModel.EndDate,
                UserId = Request.Cookies["userInfo"]["Id"]

            };

            _carContext.Rents.Add(rent);
            _carContext.SaveChanges();

            TempData["entity"] = orderViewModel;

            return RedirectToAction("EndOrder");
        }
        [Authorize(Roles = "User")]
        public ActionResult EndOrder(OrderViewModel orderViewModel)
        {
            if (TempData["entity"] == null)
            {
                return HttpNotFound();
               
            }
 
           
            return View((OrderViewModel)TempData["entity"]);
        }


    }

}