using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using website.identity;
using website.Models;

namespace website.Controllers
{  [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        private UserManager<ApplicationUser> userManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new CustomPasswordValidator()
            {
                RequireDigit = true,
                RequiredLength=8,
                RequireLowercase=true,
                RequireUppercase=true,
                RequireNonLetterOrDigit=true
            };
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames=false
            };
        }
        public ActionResult Index()
        {
            return View();
        } 
        [HttpGet]
        [AllowAnonymous]

        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("/RoleAdmin/Error", new string[] { "Erişim Hakkınız Yok" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid) {
                var user = userManager.Find(model.Name, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış kuulancı adı veya parlo");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true,


                    };
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);
                    return Redirect(string.IsNullOrEmpty(returnUrl)? "/":returnUrl);
    


            }
            }
            ViewBag.returnUrl = returnUrl;

            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("/Anasayfa/Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.Name;
                
                user.Email = model.Email;
                var resl = userManager.Create(user, model.Password);
                if (resl.Succeeded)
                   return RedirectToAction("Login");
                else
                    foreach(var i in resl.Errors) { ModelState.AddModelError("", i); }
                }
            
            return View(model);
        }

        

    }
}