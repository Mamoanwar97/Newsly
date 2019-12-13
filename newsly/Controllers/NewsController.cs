using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newsly.Models;

namespace newsly.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext _context;

        public NewsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: News
        public ActionResult Index(int? page)
        {
            if (!page.HasValue)
            {
                page = 0;
            }
            var ViewModel = new NewsPanel()
            {
                Current = (int)page,
                News = _context.Newsletters.ToList()
            };
            //var newsletters = _context.Newsletters.ToList().Skip(4 * (int)page);
            return View(ViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Newsletter newLetter)
        {
            if (ModelState.IsValid)
            {
                if (newLetter.Id == 0)
                {
                    _context.Newsletters.Add(newLetter);
                }
                else
                {
                    var newsInDb = _context.Newsletters.Single(n => n.Id == newLetter.Id);

                    newsInDb.Title = newLetter.Title;
                    newsInDb.Author = newLetter.Author;
                    newsInDb.Description = newLetter.Description;
                    newsInDb.Img_link = newLetter.Img_link;
                    newsInDb.Date = newLetter.Date;

                }
                _context.SaveChanges();
                return RedirectToAction("Index", "News");
            }
            else
            {
                return View("Modify");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Modify()
        {
            var viewer = new NewsModifier
            {
                condition = "Add News"
            };
            return View(viewer);
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int Id)
        {
            var news = _context.Newsletters.SingleOrDefault(n => n.Id == Id);
            var viewer = new NewsModifier(news)
            {
                condition = "Editing News",
            };
            if (news == null)
                return HttpNotFound();

            return View("Modify", viewer);
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int Id)
        {
            var news = _context.Newsletters.SingleOrDefault(n => n.Id == Id);

            if (news == null)
                return HttpNotFound();

            _context.Newsletters.Remove(news);
            _context.SaveChanges();

            return RedirectToAction("Index", "News");
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