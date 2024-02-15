using MvcOnlineWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineWeb.Controllers
{
    public class IstatislikController : Controller
    {
        // GET: İstatislik
        context c = new context();
        public ActionResult Index()
        {
            var d1 = c.caris.Count().ToString();
            ViewBag.d1 = d1;
            var d2 = c.uruns.Count().ToString();
            ViewBag.d2 = d2;
            var d3 = c.Personels.Count().ToString();
            ViewBag.d3 = d3;
            var d4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = d4;

            var d5 = c.uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = d5;
            var d6 = (from x in c.uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = d6;
            var d7 = c.uruns.Count(x => x.Stok <= 5).ToString();
            ViewBag.d7 = d7;
            var d8 = (from x in c.uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = d8;

            var d9 = (from x in c.uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = d9;
            var d10 = c.uruns.Count(x=>x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = d10;
            var d11 = c.uruns.Count(x => x.UrunAd == "Notebook").ToString();
            ViewBag.d11 = d11;
            var d12 = c.uruns.Count().ToString();
            ViewBag.d12 = d12;

            var d13 = c.uruns.Count().ToString();
            ViewBag.d13 = d13;
            var d14 = c.SatisHarekets.Sum(x=>x.ToplamTutar).ToString();
            ViewBag.d14 = d14;

            DateTime Thisday = DateTime.Now;
            var d15 = c.SatisHarekets.Count(x=>x.Tarih == Thisday).ToString();
            ViewBag.d15 = d15;
            var d16 = c.SatisHarekets.Count().ToString();
            ViewBag.d16 = d16;

            return View();
        }

        public ActionResult KolayTablolar() {
            var deger = from x in c.caris group x by x.CariSehir into g select new Istatislik
            {
                Sehir = g.Key,
                Sayi = g.Count()
        };

            return View(deger.ToList()); 
        }

        public ActionResult Partial1()
        {
            var deger = from x in c.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new İstatislik2
                        {
                            Departman = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(deger.ToList());
        }

        public ActionResult Partial2()
        {
            var deger = c.Personels.ToList();
            return PartialView(deger);
        }

        public ActionResult Partial3()
        {
            var deger = c.caris.ToList();
            return PartialView(deger);
        }

        public ActionResult Partial4()
        {
            var deger = c.uruns.Where(x=> x.Durum == true).ToList();
            deger.GroupBy(x=> x.Stok);
            return PartialView(deger.Take(4));
        }
    }
}