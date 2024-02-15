using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class CariController : Controller
    {
        context c = new context();
        // GET: Cari
        public ActionResult Index()
        {
            var cc = c.caris.ToList();
            return View(cc);
        }

        [HttpGet]
        public ActionResult CariEkle() 
        {
            return View("CariEkle");
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            c.caris.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cc = c.caris.Find(id);
            c.caris.Remove(cc);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGuncelle(int id)
        {
            var cc = c.caris.Find(id);
            return View("CariGuncelle",cc);
        }

        public ActionResult CariDegistir(Cari cari)
        {
            var cc = c.caris.Find(cari.CariID);
            cc.CariAd = cari.CariAd;
            cc.CariSoyad = cari.CariSoyad;
            cc.CariSehir = cari.CariSehir;
            cc.CariMail = cari.CariMail;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariDetay(int id)
        {
            var cc = c.SatisHarekets.Where(x=>x.CariId == id).ToList();
            return View("CariDetay",cc);
        }
    }
}