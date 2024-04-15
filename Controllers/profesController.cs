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
    public class profesController : Controller
    {
        private escuela_caninaEntities db = new escuela_caninaEntities();

        // GET: profes
        public ActionResult Index()
        {
            return View(db.profes.ToList());
        }

        // GET: profes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profes profes = db.profes.Find(id);
            if (profes == null)
            {
                return HttpNotFound();
            }
            return View(profes);
        }

        // GET: profes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: profes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_profe,nom_profe,tipo_profe,tel_profe")] profes profes)
        {
            if (ModelState.IsValid)
            {
                db.profes.Add(profes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profes);
        }

        // GET: profes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profes profes = db.profes.Find(id);
            if (profes == null)
            {
                return HttpNotFound();
            }
            return View(profes);
        }

        // POST: profes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_profe,nom_profe,tipo_profe,tel_profe")] profes profes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profes);
        }

        // GET: profes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profes profes = db.profes.Find(id);
            if (profes == null)
            {
                return HttpNotFound();
            }
            return View(profes);
        }

        // POST: profes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profes profes = db.profes.Find(id);
            db.profes.Remove(profes);
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
