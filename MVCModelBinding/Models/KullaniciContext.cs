using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCModelBinding.Models
{
    public class KullaniciContext : DbContext
    {
        public KullaniciContext() : base("KCon")
        {

        }

        public virtual DbSet<Kullanici> Kullanicilar { get; set; }

        public System.Data.Entity.DbSet<MVCModelBinding.Models.Kategori> Kategoris { get; set; }

        public System.Data.Entity.DbSet<MVCModelBinding.Models.AlinanNot> AlinanNots { get; set; }
    }
}