using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class UrunDetaylarController : Controller
    {
        context c = new context();
        // GET: UrunDetaylar
        public ActionResult Index()
        {
            var degerler = c.uruns.Where(x=> x.UrunId == 1).ToList();
            return View(degerler);
        }
    }
}