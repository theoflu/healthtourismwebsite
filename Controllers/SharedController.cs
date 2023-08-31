using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;

namespace website.Controllers
{
    public class SharedController : Controller
    {
        // GET:
        context c = new context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult navBar()
        {
            var md = c.signups.ToList();



            return PartialView(md);
        }
    }
}