using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class brysl_ulklr
    {
        public IEnumerable<sigorta_edilen> Sigorts { get; set; }
        public IEnumerable<ulkeler> Ulks { get; set; }
    }
}