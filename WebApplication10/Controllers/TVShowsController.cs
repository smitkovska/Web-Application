using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class TVShowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TVShows
        public ActionResult Index()
        {
            return View(db.TVShows.ToList());
        }

        // GET: TVShows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVShow tVShow = db.TVShows.Find(id);
            if (tVShow == null)
            {
                return HttpNotFound();
            }
            return View(tVShow);
        }

        // GET: TVShows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,DownloadURL,ImageURL,Rating,Genre")] TVShow tVShow)
        {
            if (ModelState.IsValid)
            {
                db.TVShows.Add(tVShow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tVShow);
        }

        // GET: TVShows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVShow tVShow = db.TVShows.Find(id);
            if (tVShow == null)
            {
                return HttpNotFound();
            }
            return View(tVShow);
        }

        // POST: TVShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,DownloadURL,ImageURL,Rating,Genre")] TVShow tVShow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVShow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tVShow);
        }

        // GET: TVShows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVShow tVShow = db.TVShows.Find(id);
            if (tVShow == null)
            {
                return HttpNotFound();
            }
            return View(tVShow);
        }

        // POST: TVShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVShow tVShow = db.TVShows.Find(id);
            db.TVShows.Remove(tVShow);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
