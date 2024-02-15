using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineWeb.Models.Classes
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }
        public string TeslimEden { get; set; }
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> faturaKalems { get; set; }
    }
}