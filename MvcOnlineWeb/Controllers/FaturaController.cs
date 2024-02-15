using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class FaturaController : Controller
    {

        context c = new context();
        // GET: Fatura
        public ActionResult Index()
        {
            var deger = c.Faturas.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniFatura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniFatura(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return View("Index");
        }

        public ActionResult FaturaGuncelle(int id)
        {
            var deger = c.Faturas.Find(id);
            return View(deger);
        }

        public ActionResult FaturaDegistir(Fatura f)
        {
            var deger = c.Faturas.Find(f.FaturaId);
            deger.FaturaSıraNo = f.FaturaSıraNo;
            deger.FaturaSeriNo = f.FaturaSeriNo;
            deger.Tarih = f.Tarih;
            deger.Saat = f.Saat;
            deger.VergiDairesi = f.VergiDairesi;
            deger.TeslimAlan = f.TeslimAlan;
            deger.TeslimEden = f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var dgr = c.FaturaKalems.Where(x=>x.FaturalarId == id).ToList();
            return View(dgr);
        }
    }
}