using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class ulkeler
    {
        [Key]
        public int ID { get; set; }
        public string ulke { get; set; }
        public string ulkekd { get; set; }
    }
}