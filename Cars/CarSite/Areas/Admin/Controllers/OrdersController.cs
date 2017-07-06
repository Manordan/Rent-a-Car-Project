using CarSite.Models;
using CarSite.ViewModel;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CarSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class OrdersController : Controller
    {
        CarContext _carContext;

        public OrdersController()
        {
            _carContext = new CarContext();

        }
        // GET: Admin/Orders
        public ActionResult Index()
        {
            var orders = _carContext.Rents
                  .Select(r => new OrdersViewModel
                  {
                      FirstName = r.User.FirstName,
                      LastName = r.User.LastName,
                      OrderId = r.Id,
                      CarManufacturer= r.Car.CarModel.CarManufacturer.Name,
                      CarModel= r.Car.CarModel.Model,
                      CarId = r.Car.Id,
                      StartDate = r.StartDate,
                      EndDate = r.EndtDate,
                      ReturnDate = r.ReturnDate,
                      DailyCost = r.Car.CarModel.DailyCost,
                      DailyCostDelay = r.Car.CarModel.DailyCostDelay

                  }

                  ).ToList();

            return View(orders);
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orderDetails = _carContext.Rents.Where(o => o.Id == id);

            var ordersViewModel = orderDetails.Select(r => new OrdersViewModel
            {
                FirstName = r.User.FirstName,
                LastName = r.User.LastName,
                OrderId = r.Id,
                CarManufacturer = r.Car.CarModel.CarManufacturer.Name,
                CarModel = r.Car.CarModel.Model,
                CarId = r.Car.Id,
                StartDate = r.StartDate,
                EndDate = r.EndtDate,
                ReturnDate = r.ReturnDate,
                DailyCost = r.Car.CarModel.DailyCost,
                DailyCostDelay = r.Car.CarModel.DailyCostDelay
            }).FirstOrDefault();

            if (ordersViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ordersViewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orderDetails = _carContext.Rents.Where(o => o.Id == id);

            var ordersViewModel = orderDetails.Select(r => new OrdersViewModel
            {
                FirstName = r.User.FirstName,
                LastName = r.User.LastName,
                OrderId = r.Id,
                CarManufacturer = r.Car.CarModel.CarManufacturer.Name,

                CarModel = r.Car.CarModel.Model,

                CarId = r.Car.Id,
                StartDate = r.StartDate,
                EndDate = r.EndtDate,
                ReturnDate = r.ReturnDate,
                DailyCost = r.Car.CarModel.DailyCost,
                DailyCostDelay = r.Car.CarModel.DailyCostDelay,
               
            }).FirstOrDefault();

            if (ordersViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ordersViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ReturnDate")] OrdersViewModel order)
        {
            if (order.ReturnDate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orderClose = _carContext.Rents.Where(o => o.Id == order.OrderId).FirstOrDefault();
            if(orderClose!=null)
            {
                orderClose.ReturnDate = order.ReturnDate;
                _carContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return HttpNotFound();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Rent rent = _carContext.Rents.Where(u => u.Id == id).FirstOrDefault();

            if (rent != null)
            {
                _carContext.Rents.Remove(rent);
                _carContext.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);


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