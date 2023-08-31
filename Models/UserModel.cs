using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using website.identity;

namespace website.Models
{
    public class LoginModel {

        public string Name { get; set; }
        public string Password { get; set; }

    }

    public class UserModel
    {
        public string Name { get; set; }
        public string kullanici { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> Nonmembers { get; set; }
    }

    public class RoleUpdateModel
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdstoAdd { get; set; }
        public string[] IdstoDelete { get; set; }
    }
    public class UserUpdateModel
    {
        public string kullanici { get; set; }
        public string sifre { get; set; }
    }
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }


}
   