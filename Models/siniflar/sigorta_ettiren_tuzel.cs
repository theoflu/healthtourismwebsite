using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;


namespace website.Models.sınıflar
{
    public class sigorta_ettiren_tuzel
    {
        public int ID { get; set; }
        public string VergiNo { get; set; }
        public string VTlfn { get; set; }
        public string VEposta { get; set; }
        public ICollection<sigorta_edilen> sigorta_edilens { get; set; }
 
    }
}