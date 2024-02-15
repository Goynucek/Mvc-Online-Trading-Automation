using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineWeb.Models.Classes
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public Decimal Fiyat { get; set; }
        public Decimal ToplamTutar { get; set; }


        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }
        
        public virtual Urun urun { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }
    }
}