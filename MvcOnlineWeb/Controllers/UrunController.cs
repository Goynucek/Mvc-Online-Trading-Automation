using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcOnlineWeb.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineWeb.Controllers
{
    public class UrunController : Controller
    {
        context c = new context();
        // GET: Urun
        public ActionResult Index(int sayfa = 1)
        {
            var urunler = c.uruns.Where(x =>x.Durum == true).ToList().ToPagedList(sayfa,4);
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                //string dosyauzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                u.UrunGorsel = "/Image/" + dosyaadi;
            }
            c.uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ktgr = c.uruns.Find(id);

            return View("UrunGuncelle", ktgr);
        }

        public ActionResult UrunDegistir(Urun u)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                //string dosyauzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                u.UrunGorsel = "/Image/" + dosyaadi;
            }
            var deger = c.uruns.Find(u.UrunId);
            deger.UrunAd = u.UrunAd;
            deger.Marka = u.Marka;
            deger.Stok = u.Stok;
            deger.AlisFiyat = u.AlisFiyat;
            deger.Kategoriid = u.Kategoriid;
            deger.UrunGorsel = u.UrunGorsel;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}