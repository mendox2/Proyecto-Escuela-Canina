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
    public class peludosController : Controller
    {
        private escuela_caninaEntities db = new escuela_caninaEntities();

        // GET: peludos
        public ActionResult Index()
        {
            return View(db.peludos.ToList());
        }

        // GET: peludos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peludos peludos = db.peludos.Find(id);
            if (peludos == null)
            {
                return HttpNotFound();
            }
            return View(peludos);
        }

        // GET: peludos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: peludos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_pel,nom_pel,tipo_trato_pel,raza_pel,tel_pap")] peludos peludos)
        {
            if (ModelState.IsValid)
            {
                db.peludos.Add(peludos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peludos);
        }

        // GET: peludos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peludos peludos = db.peludos.Find(id);
            if (peludos == null)
            {
                return HttpNotFound();
            }
            return View(peludos);
        }

        // POST: peludos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_pel,nom_pel,tipo_trato_pel,raza_pel,tel_pap")] peludos peludos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peludos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peludos);
        }

        // GET: peludos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peludos peludos = db.peludos.Find(id);
            if (peludos == null)
            {
                return HttpNotFound();
            }
            return View(peludos);
        }

        // POST: peludos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            peludos peludos = db.peludos.Find(id);
            db.peludos.Remove(peludos);
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
