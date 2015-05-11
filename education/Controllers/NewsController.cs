using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using education.Models;

namespace education.Controllers
{
    public class NewsController : Controller
    {
        private educationEntities db = new educationEntities();

        // GET: /News/
        public ActionResult Index()
        {
            var query = (from c in db.categories
                         from x in db.contents
                         where c.parent_id == 2 && x.catid == c.id
                         select x);
            
            return View(query);
        }

        // GET: /News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            content content = db.contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: /News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,title,introtext,fulltext,state,catid,created,create_by,image,ordering,hit")] content content)
        {
            if (ModelState.IsValid)
            {
                db.contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(content);
        }

        // GET: /News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            content content = db.contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: /News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,title,introtext,fulltext,state,catid,created,create_by,image,ordering,hit")] content content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        // GET: /News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            content content = db.contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: /News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            content content = db.contents.Find(id);
            db.contents.Remove(content);
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
        public ActionResult NewsRelated()
        {

            return PartialView(db.contents.Where(a => a.catid == 2).OrderByDescending(a => a.id).Take(4));
        }
        public ActionResult TypeOfNews()
        {

            return PartialView(db.categories.Where(c => c.parent_id == 2));
        }
    }
}
