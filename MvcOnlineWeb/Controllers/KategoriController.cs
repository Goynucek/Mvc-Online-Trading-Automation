using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class KategoriController : Controller
    {
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle() {         
            return View(); 
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktgr = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = c.Kategoris.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}