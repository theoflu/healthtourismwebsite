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

    public class BuyController : Controller
    {
        // GET: Buy
        context c = new context();
       

        public ActionResult Index()
        {
      

            return View();
        }
        [HttpGet]
        public PartialViewResult Satn_Al()
        {
            var modl = new ForBuy();
            modl.planLists = c.kmplksyn_plans.ToList();


            List < SelectListItem > dgr= (from i in c.ulkelers.ToList()
                         select new SelectListItem
                         {
                             Text = i.ulke,
                             Value = i.ulke

                         }).ToList();

            ViewBag.Uyruk = dgr;
           
            List < SelectListItem > dgr2 = (from i in c.ulkelers.ToList()
                           select new SelectListItem
                           {
                               Text = i.ulke + " (+ " + i.ulkekd + ")",
                               Value = i.ulkekd
                           }).ToList();

            ViewBag.Tlfn_kdu = dgr2;



            return PartialView(modl);
        }
        [HttpPost]
        public PartialViewResult Satn_Al(ForBuy se)
        {
            se.db.KsmTrh = DateTime.Now;
            if (se.db.soru != true)
            {
               
                if (se.db.s_ettrn == "B")
                {
                    var modl2 = new ForBuy();
                    modl2.planLists = c.kmplksyn_plans.ToList();
                    List<SelectListItem> dgr = (from i in c.ulkelers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.ulke,
                                                    Value = i.ulke
                                                }).ToList();

                    ViewBag.Uyruk = dgr;

                    List<SelectListItem> dgr2 = (from i in c.ulkelers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.ulke + " (+ " + i.ulkekd + ")",
                                                     Value = i.ulkekd
                                                 }).ToList();

                    ViewBag.Tlfn_kdu = dgr2;
                    BuyFormValidator bfv = new BuyFormValidator();

                    ValidationResult rslt = bfv.Validate(se);


                    if (rslt.IsValid)
                    {
                        c.sigorta_edilens.Add(se.db);
                        c.SaveChanges();
                        return PartialView(modl2);
                    }
                    else
                    {
                        foreach (var item in rslt.Errors)
                        {
                       

                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }

                    }
                }
                else if (se.db.s_ettrn == "T")
                {
                    var modl3 = new ForBuy();
                    modl3.planLists = c.kmplksyn_plans.ToList();
                    List<SelectListItem> dgr = (from i in c.ulkelers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.ulke,
                                                    Value = i.ulke
                                                }).ToList();

                    ViewBag.Uyruk = dgr;

                    List<SelectListItem> dgr2 = (from i in c.ulkelers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.ulke + " (+ " + i.ulkekd + ")",
                                                     Value = i.ulkekd
                                                 }).ToList();

                    ViewBag.Tlfn_kdu = dgr2;
                    BuyFormValidator1 bfv1 = new BuyFormValidator1();
                    se.db.sigorta_Ettiren_brysel.sgettren_Dtarihi = DateTime.Now;
                    ValidationResult rslt1 = bfv1.Validate(se);


                    if (rslt1.IsValid)
                    {
                        c.sigorta_edilens.Add(se.db);
                        c.SaveChanges();
                        return PartialView(modl3);
                    }
                    else
                    {
                        foreach (var item in rslt1.Errors)
                        {

                          
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                        }

                    }

                }
            }
            else
            {
                var modl = new ForBuy();
                modl.planLists = c.kmplksyn_plans.ToList();
                List<SelectListItem> dgr = (from i in c.ulkelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.ulke,
                                                Value = i.ulke
                                            }).ToList();

                ViewBag.Uyruk = dgr;

                List<SelectListItem> dgr2 = (from i in c.ulkelers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ulke + " (+ " + i.ulkekd + ")",
                                                 Value = i.ulkekd
                                             }).ToList();

                ViewBag.Tlfn_kdu = dgr2;
                BuyFormValidator2 bfv2 = new BuyFormValidator2();
                se.db.s_ettrn = " ";
                se.db.sigorta_Ettiren_brysel.ID = 0;
                se.db.sigorta_ettiren_tuzel.ID = 0;
                ValidationResult rslt2 = bfv2.Validate(se);
               

                if (rslt2.IsValid)
                {
                  
                    c.sigorta_edilens.Add(se.db);
                    c.SaveChanges();
                    return PartialView(modl);
                }
                else
                {
                    foreach (var item in rslt2.Errors)
                    {
                       

                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }

                }
            }


            var modl4 = new ForBuy();
            modl4.planLists = c.kmplksyn_plans.ToList();
            return PartialView(modl4);
        }


        public PartialViewResult Planlar()
        {
            var degerler = c.kmplksyn_plans.ToList();
            

            return PartialView(degerler);
        }

        //public JsonResult Fyt(int p)
        //{
        //    c.Configuration.ProxyCreationEnabled = false;
        //    List<kmplksyn_plan> List = c.kmplksyn_plans.Where(x => x.ID == p).ToList();
        //    return Json(List, JsonRequestBehavior.AllowGet);

        //}
        public JsonResult Fyt(int p)
        {
            c.Configuration.ProxyCreationEnabled = false;
            var fytlar = (from x in c.kmplksyn_plans
                          join y in c.plan_prices on x.plan_price.ID equals y.ID
                          where x.plan_price.ID == p
                          select new
                          {
                              Plan = x.Baslik,
                              Text = x.plan_price.kumsz_prim,
                              Value = "EUR"
                          }).ToList();
            var jsonW = JsonConvert.SerializeObject(fytlar);
            return Json(jsonW, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_kum(int p)
        {

            c.Configuration.ProxyCreationEnabled = false;
            var fytlar = (from x in c.kmplksyn_plans
                          join y in c.plan_prices on x.plan_price.ID equals y.ID
                          where x.plan_price.ID == p
                          select new
                          {
                              Plan = x.Baslik,
                              Text = x.plan_price.kum_dhl_prim,
                              Value = "EUR"
                          }).ToList();
            var jsonW = JsonConvert.SerializeObject(fytlar);
            return Json(jsonW, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_rfkt_km(int p)
        {

            c.Configuration.ProxyCreationEnabled = false;
            var fytlar = (from x in c.kmplksyn_plans
                          join y in c.plan_prices on x.plan_price.ID equals y.ID
                          where x.plan_price.ID == p
                          select new
                          {
                              Plan = x.Baslik,
                              Text = x.plan_price.kum_rfktc_dhl,
                              Value = "EUR"
                          }).ToList();
            var jsonW = JsonConvert.SerializeObject(fytlar);
            return Json(jsonW, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_rfkt(int p)
        {

            c.Configuration.ProxyCreationEnabled = false;
            var fytlar = (from x in c.kmplksyn_plans
                          join y in c.plan_prices on x.plan_price.ID equals y.ID
                          where x.plan_price.ID == p
                          select new
                          {
                              Plan = x.Baslik,
                              Text = x.plan_price.rfktc_dhl,
                              Value = "EUR"
                          }).ToList();
            var jsonW = JsonConvert.SerializeObject(fytlar);
            return Json(jsonW, JsonRequestBehavior.AllowGet);
        }



        //context db=new context();
        //JsonResult Pln_fyt()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    List<plan_price> plist = db.plan_prices.ToList();
        //    return Json(plist, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Getid(int p)
        //{
        //    c.Configuration.ProxyCreationEnabled = false;

        //    var findW = c.plan_prices.FirstOrDefault(x => x.ID == p);
        //    var jsonW = JsonConvert.SerializeObject(findW);
        //    return Json(jsonW, JsonRequestBehavior.AllowGet);
        //    //db.Configuration.ProxyCreationEnabled = false;
        //    //List<plan_price> plist = db.plan_prices.ToList();
        //    //return Json(plist, JsonRequestBehavior.AllowGet);
        //    //var fytlar = (from x in c.kmplksyn_plans
        //    //              join y in c.plan_prices on x.plan_price.ID equals y.ID
        //    //              where x.plan_price.ID == p
        //    //              select new
        //    //              {
        //    //                  Text = x.plan_price.kumsz_prim,
        //    //                  Value = x.ID.ToString()
        //    //              }).ToList();
        //    //return Json(fytlar, JsonRequestBehavior.AllowGet);

        //}
    }
}
