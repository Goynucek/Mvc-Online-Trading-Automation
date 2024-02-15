using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class PersonelController : Controller
    {
        context c = new context();
        // GET: Personel
        public ActionResult Index()
        {
            var p = c.Personels.ToList();
            return View(p);
        }

        public ActionResult PersonelSil(int id)
        {
            var p = c.Personels.Find(id);
            c.Personels.Remove(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View("PersonelEkle"); 
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGuncelle(int id)
        {
            var p = c.Personels.Find(id);
            return View("PersonelGuncelle",p);
        }

        public ActionResult PersonelGonder(Personel p)
        {
            var pp = c.Personels.Find(p.PersonelId);
            pp.PersonelAd = p.PersonelAd;
            pp.PersonelSoyad = p.PersonelSoyad;
            pp.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}