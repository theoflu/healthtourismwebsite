using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;

namespace website.Controllers
{

    [AllowAnonymous]

    public class AnasayfaController : Controller
    {
        // GET: Anasayfa

        context c = new context();
        anasyf_price ap = new anasyf_price();
        public ActionResult Index()
        {
            //var degerler = c.kmplksyn_plans.ToList();
            ap.anasyfdgr = c.anasayfas.ToList();
            ap.kmplkstnplndgr = c.kmplksyn_plans.ToList();
            return View(ap);

        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Buy()
        {
            return View();
        }




    }

}