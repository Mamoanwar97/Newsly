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
        [Authorize(Roles = "Admin")]

        public ActionResult Index()
        {
            ViewBag.Message = "Home";
            var newsletters = _context.Newsletters.ToList();
            return View(newsletters);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

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