using CarSite.Common;
using CarSite.Models;
using CarSite.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CarSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        CarContext _carContext;
        UsersFunc _usersFunc;
        public UsersController()
        {
            _carContext = new CarContext();
            
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = _carContext.Users.ToList();
            return View(users);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _carContext.Users.Where(c => c.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            UserWitheRolesViewModel userWitheRolesViewModel = new UserWitheRolesViewModel();

            return View(userWitheRolesViewModel);
        }

        [HttpPost]
        public ActionResult Create(User user, string[] roles)
        {
            if (ModelState.IsValid)
            {
                _carContext.Users.Add(user);
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }

            _usersFunc = new UsersFunc();
            var userWitheRolesViewModel = _usersFunc.UserCreate(user, roles);

            return View(userWitheRolesViewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _carContext.Users.Where(c => c.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }

            _usersFunc = new UsersFunc();
            var userWitheRolesViewModel = _usersFunc.UserEdit(user, id);
 
            return View(userWitheRolesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user, string[] roles)
        {
            if (ModelState.IsValid)
            {
                _carContext.Entry(user).State = EntityState.Modified;

                var roleToRemove = _carContext.Roles.Where(r => r.UserId == user.Id).ToList();

                if (roleToRemove != null)
                {
                    _carContext.Roles.RemoveRange(roleToRemove);
                }

                if (roles!= null && roles.Length>0)
                {
                    foreach (var item in roles)
                    {
                        var role = new Role
                        {
                            UserId = user.Id,
                            Authorization = item
                        };

                        _carContext.Roles.Add(role);

                    }
                }
                _carContext.SaveChanges();
                return RedirectToAction("Index");
            }

            _usersFunc = new UsersFunc();
            var userWitheRolesViewModel = _usersFunc.UserCreate(user, roles);

            return View(userWitheRolesViewModel);
           
        }


        [HttpDelete]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            User user = _carContext.Users.Where(u=>u.Id==id).FirstOrDefault();

            if(user!= null)
            {
                _carContext.Users.Remove(user);
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