using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace website.identity
{
    public class CustomPasswordValidator:PasswordValidator
    {
        public override  async Task<IdentityResult> ValidateAsync(string password)
        {
            var result = await base.ValidateAsync(password);
            if (password.Contains("12345"))
            {
                var err = result.Errors.ToList();
                err.Add("Parola ardışık sayısal ifade içeremez");
                result = new IdentityResult(err);
            }
            return result;
          
        }
    }
}