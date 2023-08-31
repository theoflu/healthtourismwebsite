using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;
using Microsoft.AspNet.Identity.EntityFramework;

namespace website.Models.sınıflar
{
    public class signup
    {   [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public string psprtno { get; set; }
        public string email { get; set; }
        public string telno { get; set; }
        public string sclno { get; set; }
        public string paswrd { get; set; }
        public bool gzllk_ony { get; set; }
    }
}