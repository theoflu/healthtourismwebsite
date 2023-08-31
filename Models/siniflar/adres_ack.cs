using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class adres_ack
    {
        [Key]
        public int ID { get; set; }
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public string acikadres { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }

    }
}