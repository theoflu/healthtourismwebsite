using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;


namespace website.Controllers
{
    [AllowAnonymous]

    public class PlansController : Controller
    {
        // GET: Plans
        context d = new context();
        public ActionResult Index()
        {
            //var planbul = c.kmplksyn_plans.Where(x => x.ID == id).ToList();
            var degerler = d.kmplksyn_plans.ToList();
            return View(degerler);
        }
    }
}