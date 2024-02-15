using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        context c = new context();
        public ActionResult Index()
        {
            var departman = c.departmens.Where(x => x.Durum == true).ToList();
            return View(departman);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            c.departmens.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult DepartmanSil(int d) 
        {
            var dgr = c.departmens.Find(d);
            dgr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var value = c.departmens.Find(id);
            return View("DepartmanGetir", value);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var value = c.departmens.Find(d.DepartmanId);
            value.Durum = true;
            value.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var kgrt = c.Personels.Where(x=>x.DepartmanId == id).ToList();
            var departman = c.departmens.Find(id);
            ViewBag.departmanadi = departman.DepartmanAd.ToString();
            return View(kgrt);
        }

        public ActionResult DepartmanPersonelSatıs(int id)
        {
            var dps = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var eleman = c.Personels.Find(id);
            ViewBag.elemanisim = (eleman.PersonelAd+" "+ eleman.PersonelSoyad);
            return View("DepartmanPersonelSatıs",dps);
        }
    }
}