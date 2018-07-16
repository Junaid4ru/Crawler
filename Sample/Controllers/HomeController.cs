using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private CrawlerFlightEntities db;
        public HomeController()
        {
            db = new CrawlerFlightEntities();
            
        }
        public ActionResult Index()
        {
            
            var data = db.CrawlerFlights.ToList();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}