using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class about
    {
        [Key]
        public int ID { get; set; }

        public string FotoUrl { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string quote { get; set; }
        public string modal_madde { get; set; }
    }
}