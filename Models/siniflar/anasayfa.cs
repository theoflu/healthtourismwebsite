using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Dynamic;

namespace website.Models.sınıflar
{
    public class anasayfa
    {
        [Key]
        public int ID { get; set; }
        public string Baslik1 { get; set; }
        public string Baslik2 { get; set; }
        public string FotoUrl { get; set; }
        public string Aciklama { get; set; }
        public DateTime Grisym { get; set; }

    }

}