using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace website.Models.sınıflar
{
    public class kmplksyn_plan
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Acklma { get; set; }
        public string FotoUrl { get; set; }
        public virtual plan_price plan_price { get; set; }

        public ICollection<sigorta_edilen> sigorta_edilens { get; set; }


    }
}