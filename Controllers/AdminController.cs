using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;
using FluentValidation;
using website.ValidationRules;
using FluentValidation.Results;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using website.identity;
using Microsoft.AspNet.Identity.EntityFramework;
using website.Models;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace website.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        context c = new context();
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
      
         
    
        public AdminController()
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
                AllowOnlyAlphanumericUserNames = false,
                
            };
        }
        public ActionResult Index()
        {
            var degerler = c.sigorta_edilens.ToList();
            
            return View(degerler);
        }
       
        public ActionResult SigortaEttiren(int id)
                
        {

            var dgr = c.sigorta_ettiren_brysels.Where(x => x.ID == id).ToList();

            return View(dgr);

            //var model = c.sigorta_ettiren_brysels.Find(id);

            //    return View("SigortaEttiren",model);
        }
     
        public ActionResult SigortaEttirenT(int id)
        {
            var dgr = c.sigorta_ettiren_brysels.Where(x => x.ID == id).ToList();

            return View(dgr);

        }
     
        public ActionResult SigortaEttirenK(int id)
        {
            var dgr = c.sigorta_edilens.Where(x => x.ID == id).ToList();

            return View(dgr);

        }
        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult Login()
        //{
          

        //    return View();

        //}
        //[AllowAnonymous]

        //[HttpPost]
        //public ActionResult Login(admin p)
        //{
        //    var admuser = c.admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.sifre==p.sifre);
        //    if (admuser != null)
        //    {
        //        //işlems
        //        FormsAuthentication.SetAuthCookie(admuser.Kullanici,false);
        //        Session["Kullanici"] = admuser.Kullanici;
               
        //      return  RedirectToAction("Index","Admin");

        //    }
        //    else
        //    {
        //     return   RedirectToAction("Login");
        //    }

            

        //}
        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login", "Admin");

        //}
        public ActionResult DoktorKaytilari()
        {
            var dktrlr = c.signups.ToList();
           
     
          
            return View(dktrlr);

        }  
       
        public ActionResult KestigiPoliceler(string id)
        {
           
            var plclr = c.sigorta_edilens.Where(x =>x.sigorta_Ettiren_brysel.sgettren_PasaportNo== id).ToList();// iki veri tabanı liste yapılıcak ordaki pasaport değeri sorgulanıp ona göre değerler getirilecek
            var s = plclr.Find(x => x.PasaportNo == id);
            //var s = plclr.Find(x => x.sigorta_Ettiren_brysel.sgettren_PasaportNo == id);
            if (s != null)
            {
                //bana edilenin bilgileri lazım ettirenin ps bilgisi ile edileinin kıyasla onu getir doktorda da aynı olay olcak o zman ama rolü doktor olanları göstercez

                ViewBag.kmn = s.PasaportNo;
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
            //var admn = c.admins.Find( adps.ID);
            //admn.sifre = adps.sifre;
            //c.SaveChanges();
            return View();


        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(UserUpdateModel model)
        {
           
            var admn = c.admins.FirstOrDefault(x => x.Kullanici == model.kullanici);
            //admn.sifre = adps.sifre;
            //c.SaveChanges();
            if (admn == null)
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
                        admn.sifre = model.sifre;
                        c.SaveChanges();
                        Logout();
                        return RedirectToAction("Index");


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
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Anasayfa");

        }
      
        public ActionResult Mail()
        {
            var blglr = c.iletisims.ToList();
            return View(blglr);

        } 
      
        
        public ActionResult okundu(int id )
        {

            var blglr = c.iletisims.Find(id);

            blglr.okndu = true;
            c.SaveChanges();
            return RedirectToAction("Mail","Admin");

        }
        public ActionResult okunmadı(int id)
        {

            var blglr = c.iletisims.Find(id);

            blglr.okndu = false;
            c.SaveChanges();
            return RedirectToAction("Mail","Admin");

        }
    }
}