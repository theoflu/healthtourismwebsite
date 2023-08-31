using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace website.Models.sınıflar
{
    public class kpm_pln
    {
        public IEnumerable<SelectListItem> fytlr { get; set; }
        public IEnumerable<SelectListItem> plnlr { get; set; }
    }
}