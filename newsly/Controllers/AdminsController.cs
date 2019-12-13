using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newsly.Models;

namespace newsly.Controllers
{
    public class AdminsController : Controller
    {
        private ApplicationDbContext _context;

        public AdminsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admins
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int? page)
        {
            if (!page.HasValue)
                page = 0;
            var admins = _context.Users.Where(a => a.Role == "Admin").ToList();
            var ViewModel = new AdminsPanel
            {
                Panel = admins,
                Current = (int)page,
            };
            return View(ViewModel);
        }
    }
}