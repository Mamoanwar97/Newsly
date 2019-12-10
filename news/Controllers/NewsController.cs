using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
                   letters = _context.Newsletters.ToList()
            };
            //var newsletters = _context.Newsletters.ToList().Skip(4 * (int)page);
;            return View(random);
        }
        public ActionResult Details(int id)
        {
            var newsletter = _context.Newsletters.SingleOrDefault(n => n.Id == id);

            if (newsletter == null)
                return HttpNotFound();

            return View(newsletter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNews(Newsletter newLetter)
        {
            if (ModelState.IsValid) { 
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
                    var viewer = new newsForm(newLetter)
                    {
                        condition = "InValid Submition",
                    };
                    return View("NewNews", viewer);
             }
        }
        public ActionResult NewNews()
        {
            var viewer = new newsForm
            {
                condition = "New News"
            };
            return View(viewer);
        }
        public ActionResult Edit(int Id)
        {
            var news = _context.Newsletters.SingleOrDefault(n => n.Id == Id);
            var viewer = new newsForm(news)
            {
                condition = "Editing News",
            };
            if (news == null)
                return HttpNotFound();
            
            return View("NewNews", viewer);
        }
    }
}