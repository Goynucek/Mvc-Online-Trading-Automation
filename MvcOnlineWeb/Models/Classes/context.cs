using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineWeb.Models.Classes
{
    public class context:DbContext
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<Cari> caris { get; set; }
        public DbSet<Departman> departmens { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> uruns { get; set; }
    }
}