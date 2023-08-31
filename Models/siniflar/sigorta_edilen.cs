using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;




namespace website.Models.sınıflar
{
    public class sigorta_edilen
    {
        [Key]
        public int ID { get; set; }

        //[Required(ErrorMessage = "{0} alanı gereklidir.")]
        //[RegularExpression(RegularExpression, ErrorMessage = "{0} alanı sadece büyük ve küçük harflerden oluşabilir.")]
        //[MinLength(5, ErrorMessage = "{0} 5 karakterden az olamaz."), MaxLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz.")]
        //[Display(Name = "Ad")]
        public string Ad { get; set; }

        //[Required(ErrorMessage = "{0} alanı gereklidir.")]
        //[RegularExpression(RegularExpression, ErrorMessage = "{0} alanı sadece büyük ve küçük harflerden oluşabilir.")]
        //[MinLength(5, ErrorMessage = "{0} 5 karakterden az olamaz."), MaxLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz.")]
        //[Display(Name = "Soyad")]
        public string Soyad { get; set; }

        //[Required(ErrorMessage = "{0} alanı gereklidir.")]
        //[RegularExpression(RegularExpression, ErrorMessage = "{0} alanı sadece büyük ve küçük harflerden oluşabilir.")]
        //[MinLength(5, ErrorMessage = "{0} 5 karakterden az olamaz."), MaxLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz.")]
        //[Display(Name = "Bana Adı")]
        public string BabaAdi { get; set; }

        public string PasaportNo { get; set; }
      
        public DateTime Dtarihi { get; set; }
        public string Dyeri { get; set; }
        public string Uyruk { get; set; }
        public string Cinsiyet { get; set; }
        public string Tlfn_kdu { get; set; }



        public string Tlfn { get; set; }

        public string planID { get; set; }
        public string  ektmntID { get; set; }
        public string  cost { get; set; }
        public string Eposta { get; set; }
        [Required(ErrorMessage = "Geliş tarihi alanı gereklidir!")]
        public DateTime Gtarihi { get; set; }
        [Required(ErrorMessage = " Tedavi tarihi alanı gereklidir!")]
        public DateTime Ttarihi { get; set; }
          [Required(ErrorMessage =" Dönüş tarihi alanı gereklidir!")]
        public DateTime Dontarihi { get; set; }
        public bool soru { get; set; }
        public string s_ettrn { get; set; }
        public virtual sigorta_ettiren_brysel sigorta_Ettiren_brysel { get; set; }
        public virtual sigorta_ettiren_tuzel sigorta_ettiren_tuzel { get; set; }
        public virtual IEnumerable<kmplksyn_plan> kmps { get; set; }
        public bool ony { get; set; }
        public bool ony1 { get; set; }
        public bool ony2 { get; set; }
        public bool ony3 { get; set; }
        public DateTime? KsmTrh { get; set; }





    }

}