using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website.Models.sınıflar
{
    public class IdentityDataContext:IdentityDbContext <signup>
    {
        public IdentityDataContext() : base("identityConnection")
        {
            

         }
    }
}