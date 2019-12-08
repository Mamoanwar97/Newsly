using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using news.Models;

namespace news.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext _context;

        public NewsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: News
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index(int? page)
        {
            if(!page.HasValue)
            {
                page = 0;
            }
            var random = new newsPage()
            {
                current = (int)page,
            };
            var newsletters = _context.Newsletters.ToList().Skip(4 * (int)page);
;            return View(newsletters);
        }
        public ActionResult Details(int id)
        {
            var newsletter = _context.Newsletters.SingleOrDefault(n => n.Id == id);

            if (newsletter == null)
                return HttpNotFound();

            return View(newsletter);
        }
    }
}