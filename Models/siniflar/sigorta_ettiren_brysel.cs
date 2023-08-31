using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;


namespace website.Models.sınıflar
{
    public class sigorta_ettiren_brysel
    {
        [Key]
        public int ID { get; set; }
        public string sgettren_Ad { get; set; }
        public string sgettren_Soyad { get; set; }
        public string sgettren_BabaAdi { get; set; }
        public string sgettren_PasaportNo { get; set; }

        //[Required]
        //public DateTime sgettren_Dtarihi { get; set; }
        public DateTime? sgettren_Dtarihi { get; set; }
        public string sgettren_Dyeri { get; set; }
        public string sgettren_Uyruk { get; set; }
        public string sgettren_Cinsiyet { get; set; }
        public string sgettren_Tlfn { get; set; }
        public string sgettren_Tlfn_kdu { get; set; }
        public string sgettren_Eposta { get; set; }

        public ICollection<sigorta_edilen> sigorta_edilens { get; set; }

    }
}