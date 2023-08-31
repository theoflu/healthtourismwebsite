using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;
namespace website.Controllers
{
    [AllowAnonymous]

    public class AboutController : Controller
    {
        // GET: About
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.abouts.ToList();
            return View(degerler);
        }
    }
}