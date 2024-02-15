using MvcOnlineWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineWeb.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        context C = new context();

        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult partial1(Cari c)
        {
            C.caris.Add(c);
            C.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Cari c)
        {
            var bilgiler = C.caris.FirstOrDefault(x=>x.CariMail == c.CariMail && x.CariPassword == c.CariPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "LogIn");
            }
        }

        public ActionResult AdminLogin(Admin a)
        {
            var bilgiler = C.admins.FirstOrDefault(x=>x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else 
            { 
                return RedirectToAction("Index", "Login");
            }
        }
    }
}