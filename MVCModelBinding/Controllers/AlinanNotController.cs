using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCModelBinding.Models;

namespace MVCModelBinding.Controllers
{
    public class AlinanNotController : Controller
    {
        private KullaniciContext db = new KullaniciContext();

        // GET: AlinanNot
        public ActionResult Index()
        {
            var alinanNots = db.AlinanNots.Include(a => a.Kategori);
            return View(alinanNots.ToList());
        }

        // GET: AlinanNot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlinanNot alinanNot = db.AlinanNots.Find(id);
            if (alinanNot == null)
            {
                return HttpNotFound();
            }
            return View(alinanNot);
        }

        // GET: AlinanNot/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi");
            return View();
        }

        // POST: AlinanNot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Yazi,KategoriId")] AlinanNot alinanNot)
        {
            if (ModelState.IsValid)
            {
                db.AlinanNots.Add(alinanNot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi", alinanNot.KategoriId);
            return View(alinanNot);
        }

        // GET: AlinanNot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlinanNot alinanNot = db.AlinanNots.Find(id);
            if (alinanNot == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi", alinanNot.KategoriId);
            return View(alinanNot);
        }

        // POST: AlinanNot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Yazi,KategoriId")] AlinanNot alinanNot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alinanNot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "KategoriAdi", alinanNot.KategoriId);
            return View(alinanNot);
        }

        // GET: AlinanNot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlinanNot alinanNot = db.AlinanNots.Find(id);
            if (alinanNot == null)
            {
                return HttpNotFound();
            }
            return View(alinanNot);
        }

        // POST: AlinanNot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlinanNot alinanNot = db.AlinanNots.Find(id);
            db.AlinanNots.Remove(alinanNot);
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
