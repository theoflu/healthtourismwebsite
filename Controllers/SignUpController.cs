using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;
using FluentValidation;
using website.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using website.identity;
using website.Models;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Net;
using System.Net.Mail;


namespace website.Controllers
{
    [Authorize(Roles = "Doktor")]
    public class SignUpController : Controller
    {
        context c = new context();
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        public SignUpController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDataContext()));
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new CustomPasswordValidator()
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireNonLetterOrDigit = true
            };
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false
               
               
            };
            

        }
        // GET: SignUp
         [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<SelectListItem> dgr = (from i in c.ulkelers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.ulkekd,
                                            Value = i.ulkekd

                                        }).ToList();

            ViewBag.u_kdu = dgr;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(signup model)
        {
            var uye = c.signups.Where(x => x.sclno == model.sclno || x.psprtno==model.psprtno);
            if (uye == null)
            {

                ModelState.AddModelError("","Pasaport numarası veya sicil numarası zaten kayıtlı");
                //hata messajı vercez

                return View("");
            }
            else
            {
                List<SelectListItem> dgr = (from i in c.ulkelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.ulkekd,
                                                Value = i.ulkekd
                                            }).ToList();

                ViewBag.u_kdu = dgr;

                DsignUpValidator dfv = new DsignUpValidator();

                ValidationResult rslt = dfv.Validate(model);


                if (rslt.IsValid)
                {
                    if (ModelState.IsValid)
                    {
                        var user = new ApplicationUser();
                        user.UserName = model.psprtno;
                        user.Email = model.email;
                        
                        var resl = userManager.Create(user, model.paswrd);
                        if (resl.Succeeded)
                        {
                            userManager.AddToRole(user.Id,"Doktor");
                            c.signups.Add(model);
                            c.SaveChanges();
                            return RedirectToAction("Login");
                         
                        }
                        else
                            foreach (var i in resl.Errors) { ModelState.AddModelError("", i); }
                    }
                   


                }
                else
                {
                    foreach (var item in rslt.Errors)
                    {


                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }

                }


                return View();
            }
        }
        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return View("Error", new string[] { "Erişim Hakkınız Yok" });
            //}
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var userr = new ApplicationUser();
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.Name, model.Password);
               //user.PasswordHash= userManager.PasswordHasher.HashPassword(user, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Yanlış Pasaport No. veya parola.");
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
                    if (user.UserName == "admin")
                    {
                        //return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
                        return RedirectToAction("Index","Admin");
                    }
                    else
                     return RedirectToAction("KestigimPoliceler");



                }
            }
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Anasayfa");

        }
        public ActionResult KestigimPoliceler(string id)
        {

            var plclr = c.sigorta_edilens.Where(x => x.sigorta_Ettiren_brysel.sgettren_PasaportNo == id).ToList();// iki veri tabanı liste yapılıcak ordaki pasaport değeri sorgulanıp ona göre değerler getirilecek
            var s = plclr.Find(x => x.PasaportNo == id);
            //var s = plclr.Find(x => x.sigorta_Ettiren_brysel.sgettren_PasaportNo == id);
            if (s != null)
            {
                //bana edilenin bilgileri lazım ettirenin ps bilgisi ile edileinin kıyasla onu getir doktorda da aynı olay olcak o zman ama rolü doktor olanları göstercez

               
                return View(plclr);
            }
            //else if  ( s1!= null)
            //  {


            //      ViewBag.kmn = s1.sigorta_Ettiren_brysel.sgettren_PasaportNo;

            //  }
            
            return View(plclr);



        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
          
            return View();


        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(UserUpdateModel model)
        {

            var usr = c.signups.FirstOrDefault(x => x.psprtno == model.kullanici);
          
            if (usr == null)
            {


                //hata messajı vercez

                return View();
            }
            else
            {

                ChangePassWordAdmn dfv = new ChangePassWordAdmn();

                ValidationResult rslt = dfv.Validate(model);
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = model.kullanici;
                user.PasswordHash = userManager.PasswordHasher.HashPassword(model.sifre);
                var rsl = await userManager.UpdateAsync(user);
                if (rsl.Succeeded)
                {

                    if (rslt.IsValid)
                    {
                        usr.paswrd = model.sifre;
                        c.SaveChanges();
                        Logout();
                        return RedirectToAction("Login","SignUp");


                    }
                    else
                    {
                        foreach (var item in rslt.Errors)
                        {


                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }

                    }

                }
                else
                {
                    foreach (var i in rsl.Errors) { ModelState.AddModelError("", i); }
                }

            }

            return View();

        }
        [HttpGet]
      public ActionResult ResetPassword( )
        {
          
            return View();

        }
        [HttpPost]
        public ActionResult ResetPassword(smtpemail mdl)
        {
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress(mdl.From);
            //msg.To.Add("mailadresi");
            //msg.Subject = mdl.Subject;
            //msg.Body = mdl.Body;
            //msg.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient("host",25);
            //smtp.Credentials = new NetworkCredential("mail","sifre");
            //smtp.EnableSsl = false;
            //smtp.Send(msg);
            //ViewBag.Message = "Mail gönderildi gardaşım ";
            //smtp.Dispose();

            return View();
        }


      



    }
   

    }
  
