using FluentValidation.Results;
using Newtonsoft.Json;
using System;
//using System.Activities.Debugger;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models.sınıflar;

using website.ValidationRules;


namespace website.Controllers
{
    [AllowAnonymous]

    public class ContactController : Controller
    {
        // GET: Contact
        contact_adres ca = new contact_adres();
        context c = new context();

        [HttpGet]
        public ActionResult Index()
        {
            ca.adrss = c.adres_acks.ToList();
          
            return View(ca);
        }
        [HttpPost]
        public ActionResult Index(contact_adres im)
        {

            var modl2 = new contact_adres();
            modl2.adrss = c.adres_acks.ToList();

            im.iltsm.mTarih = DateTime.Now;
            

           MailValidator bfv = new MailValidator();

             ValidationResult rslt = bfv.Validate(im);


             if (rslt.IsValid)
               {
                   c.iletisims.Add(im.iltsm);
                   c.SaveChanges();
                   return View(modl2);
               }
              else
              {
                    foreach (var item in rslt.Errors)
                      {


                       ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                     }

               }
            return View(modl2);
        }
      }
    }
