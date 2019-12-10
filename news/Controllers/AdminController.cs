using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using news.Models;


namespace news.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: News
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewAdmin()
        {

            return View();
        }
    }
}