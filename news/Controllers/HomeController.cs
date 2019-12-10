using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using news.Models;

namespace news.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: News
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var newsletters = _context.Newsletters.ToList();
            return View(newsletters);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(Subscriber person)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            _context.Subscribers.Add(person);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}