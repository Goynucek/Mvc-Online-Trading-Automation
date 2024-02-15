using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineWeb.Models.Classes;

namespace MvcOnlineWeb.Controllers
{
    public class GalleryController : Controller
    {
        context c = new context();
        // GET: Gallery
        public ActionResult Index()
        {
            var deger = c.uruns.ToList();
            return View(deger);
        }
    }
}