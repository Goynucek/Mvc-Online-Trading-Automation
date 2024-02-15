using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class SatıslarController : Controller
    {
        context c = new context();
        // GET: Satıslar
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Now;
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatısGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var deger = c.SatisHarekets.Find(id);

            return View("SatısGetir", deger);
        }

        public ActionResult SatısGuncelle(SatisHareket s)
        {
            var degerler = c.SatisHarekets.Find(s.SatisId);

            degerler.Adet = s.Adet;
            degerler.ToplamTutar = s.ToplamTutar;
            degerler.Fiyat = s.Fiyat;
            degerler.CariId = s.CariId;
            degerler.PersonelId = s.PersonelId;
            degerler.UrunId = s.UrunId;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}