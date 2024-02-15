using MvcOnlineWeb.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineWeb.Controllers
{
    public class CariPanelController : Controller
    {
        context c = new context();
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = Session["CariMail"].ToString();
            var deger = c.caris.FirstOrDefault(x=> x.CariMail == null);
            ViewBag.Mail = mail;
            return View(deger);
        }

        public ActionResult Siparislerim()
        {
            var mail = Session["CariMail"].ToString();
            var id = c.caris.Where(x=>x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var deger = c.SatisHarekets.Where(x=>x.CariId == id).ToList();
            return View(deger);
        }
    }
}