using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Escuela_canina.Models;

namespace Proyecto_Escuela_canina.Controllers
{
    public class papisController : Controller
    {
        private escuela_caninaEntities db = new escuela_caninaEntities();

        // GET: papis
        public ActionResult Index()
        {
            return View(db.papis.ToList());
        }

        // GET: papis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            papis papis = db.papis.Find(id);
            if (papis == null)
            {
                return HttpNotFound();
            }
            return View(papis);
        }

        // GET: papis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: papis/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tel_pap,nom_pap,fch_ingreso_pap")] papis papis)
        {
            if (ModelState.IsValid)
            {
                db.papis.Add(papis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(papis);
        }

        // GET: papis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            papis papis = db.papis.Find(id);
            if (papis == null)
            {
                return HttpNotFound();
            }
            return View(papis);
        }

        // POST: papis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tel_pap,nom_pap,fch_ingreso_pap")] papis papis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(papis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(papis);
        }

        // GET: papis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            papis papis = db.papis.Find(id);
            if (papis == null)
            {
                return HttpNotFound();
            }
            return View(papis);
        }

        // POST: papis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            papis papis = db.papis.Find(id);
            db.papis.Remove(papis);
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
