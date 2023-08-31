using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace website.Models.sınıflar
{
    public class context : DbContext
    {
        public DbSet<admin> admins { get; set; }
        public DbSet<about> abouts { get; set; }
        public DbSet<adres_ack> adres_acks { get; set; }
        public DbSet<anasayfa> anasayfas { get; set; }
        public DbSet<iletisim> iletisims { get; set; }
        public DbSet<sigorta_edilen> sigorta_edilens { get; set; }
        public DbSet<sigorta_ettiren_brysel> sigorta_ettiren_brysels { get; set; }
        public DbSet<sigorta_ettiren_tuzel> sigorta_ettiren_tuzels { get; set; }
        public DbSet<plan_price> plan_prices { get; set; }
        public DbSet<ulkeler> ulkelers { get; set; }
        public DbSet<signup> signups { get; set; }
        public DbSet<kmplksyn_plan> kmplksyn_plans { get; set; }




    }
}