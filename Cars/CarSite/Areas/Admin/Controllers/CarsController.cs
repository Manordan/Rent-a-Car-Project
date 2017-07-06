using CarSite.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace CarSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController : Controller
    {
        CarContext _carContext;

        public CarsController()
        {
            _carContext = new CarContext();

        }
        // GET: Admin/Cars
        public ActionResult Index()
        {
            var cars = _carContext.Cars.Include(m => m.CarModel.CarManufacturer).Include(m=> m.Branch).ToList();
            return View(cars);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = _carContext.Cars.Where(c=> c.Id==id).Include(m => m.CarModel.CarManufacturer).Include(m => m.Branch).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        public ActionResult Create()
        {
            return View();
        }

   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car, int? carManufacturer)
        {
            ViewBag.carManufacturer = carManufacturer;
            ViewBag.CarModelId = car.CarModelId;
            ViewBag.BranchId = car.BranchId;
            ViewBag.Picture = car.Picture;

            if (ModelState.IsValid)
            {
                _carContext.Cars.Add(car);
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = _carContext.Cars.Where(c => c.Id == id).Include(m => m.CarModel.CarManufacturer).Include(m => m.Branch).FirstOrDefault();
           
            if (car == null)
            {
                return HttpNotFound();
            }

            ViewBag.carManufacturer = car.CarModel.CarManufacturerId;
            ViewBag.CarModelId = car.CarModelId;
            ViewBag.BranchId = car.BranchId;
            ViewBag.Picture = car.Picture;

            return View(car);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Car car)
        {
            if (ModelState.IsValid)
            {
                _carContext.Entry(car).State = EntityState.Modified;
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        public ActionResult UpLoad()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = _carContext.Cars.Where(c => c.Id == id).FirstOrDefault();

            if (car != null)
            {
                _carContext.Cars.Remove(car);
                _carContext.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);


        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileUpload)
        {
            string path = "";
            string fileName = "";
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
   
                fileName = SaveFile(fileUpload);
                
            }


            string script = "<script>window.opener.document.Cars.pic_s.src = '/images/Cars/" + fileName + "'; ";
            script = script + "window.opener.document.Cars.Picture.value = '" + fileName + "'; window.close()</script>";

            return Content(script);
          
        }


        string SaveFile( HttpPostedFileBase fileUpload)
        {
            // Specify the path to save the uploaded file to.
            string savePath = Server.MapPath("~/Images/Cars/");

            // Get the name of the file to upload.
            string fileName = Path.GetFileName(fileUpload.FileName);

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
               
            }
          

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            fileUpload.SaveAs(savePath);

            return fileName;

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