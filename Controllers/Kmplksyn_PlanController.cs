using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;


namespace website.Controllers
{
    [AllowAnonymous]

    public class Kmplksyn_PlanController : Controller
    {
        // GET: Kmplksyn_Plan
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.kmplksyn_plans.ToList();
            return View(degerler);
        }
    }
}