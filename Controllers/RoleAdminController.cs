using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.identity;
using website.Models;

namespace website.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleAdminController : Controller
    {
        // GET: RoleAdmin
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        public RoleAdminController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDataContext()));
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        public ActionResult Index()
        {

            return View(roleManager.Roles);
        }
        [HttpGet]
        public ActionResult Create(  )
        {
            return View();
        }
        [HttpPost]
            public ActionResult Create( string name)
        {

            if (ModelState.IsValid)
            {
                var result = roleManager.Create(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    foreach(var i in result.Errors) { ModelState.AddModelError("", i); }
                }
            }
            return View(name);

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var role = roleManager.FindById(id);
            if (role != null)
            {
                var resl = roleManager.Delete(role);
                if (resl.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View("Error", resl.Errors);
            }
            else
                return View("Error", new string[] { "Role Bulunamadı"});


        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var role = roleManager.FindById(id);
            var members = new List<ApplicationUser>();
            var nonmembers = new List<ApplicationUser>();
            foreach(var i in userManager.Users.ToList()){
                var list = userManager.IsInRole(i.Id, role.Name)?members:nonmembers;
                list.Add(i);
            }
            return View(new RoleEditModel()
            {
                Role = role,
                Members = members,
                Nonmembers=nonmembers
                
            }) ;
        }
        [HttpPost]
        public ActionResult Edit(RoleUpdateModel model)
        {
            IdentityResult rslt ;
            if (ModelState.IsValid)
            {
                foreach(var i in model.IdstoAdd??new string[] { })
                {
                    rslt = userManager.AddToRole(i,model.RoleName);
                    if (!rslt.Succeeded)
                    {
                        return View("Error", rslt.Errors);  
                    }
                }
                foreach (var i in model.IdstoDelete ?? new string[] { })
                {
                    
                    rslt = userManager.RemoveFromRole(i, model.RoleName);
                    if (!rslt.Succeeded)
                    {
                        return View("Error", rslt.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[]{ "Aranılan rol yok"});
        }
     }
}
