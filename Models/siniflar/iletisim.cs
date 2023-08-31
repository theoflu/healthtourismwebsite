using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class iletisim
    {
        [Key]
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string mail { get; set; }
        public string mesaj { get; set; }
        public string phone { get; set; }
        public DateTime mTarih { get; set; }
        public bool okndu { get; set; }
    }
}