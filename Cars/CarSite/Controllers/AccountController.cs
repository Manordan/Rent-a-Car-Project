using CarSite.Models;
using CarSite.ViewModel;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace CarSite.Controllers
{
    public class AccountController : Controller
    {
        CarContext carContext;
        public AccountController()
        {
            carContext = new CarContext();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = carContext.Users.Where(u => u.UserName == model.UserName && u.Password == model.Password).FirstOrDefault();

            if(user!=null)
            {

                HttpCookie aCookie = new HttpCookie("userInfo");
                aCookie.Values["Id"] =user.Id;
                aCookie.Values["UserName"] = user.UserName;
                aCookie.Path = "/";
                Response.Cookies.Add(aCookie);

                FormsAuthentication.SetAuthCookie(user.UserName, false);


                var roles = carContext.Roles.Where(r => r.UserId == user.Id).ToList();
                string rolesStr = string.Empty;
                foreach (var item in roles)
                {
                    rolesStr = rolesStr + item.Authorization + ",";
                }

                if (!string.IsNullOrWhiteSpace(rolesStr))
                {
                    rolesStr = rolesStr.Substring(0,rolesStr.LastIndexOf(','));

                    HttpCookie rCookie = new HttpCookie("Roles");
                    rCookie.Value = rolesStr;
                    rCookie.Path = "/";
                    Response.Cookies.Add(rCookie);

                    if(returnUrl!=null)
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                    
            }

 

                
            }
           

            ModelState.AddModelError("", "Username or Password Incorrect");

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterViewModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                if (carContext.Users.Any(u => u.Id == model.Id || u.UserName==model.UserName))
                {
                    ModelState.AddModelError("","This Id or User Name is allready exist");
                    return View(model);
                }
                User user = new User
                {
                    Id= model.Id,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    UserName=model.UserName,
                    Password=model.Password,
                    Email=model.Email,
                    Gender=model.Gender,
 
                };

                Role role = new Role
                {
                    UserId=model.Id,
                    Authorization="User"

                };
                carContext.Users.Add(user);
                carContext.Roles.Add(role);
                carContext.SaveChanges();
                return RedirectToAction("Login",new { returnUrl= returnUrl });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();

            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                var responseCookie = Response.Cookies[cookie];
                if (responseCookie != null) responseCookie.Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (carContext != null)
                {
                    carContext.Dispose();
                    carContext = null;
                }

              
            }

            base.Dispose(disposing);
        }
    }
}