using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmacenTI.Models;

namespace AlmacenTI.Controllers
{
    public class EstatusController : Controller
    {
        private InventarioTIEntities db = new InventarioTIEntities();

        // GET: Estatus
        public ActionResult Index()
        {
            return View(db.Estatus.ToList());
        }

        // GET: Estatus/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        // GET: Estatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstatusID,Clave,Descripcion,Estatus1,FechaHora")] Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                db.Estatus.Add(estatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estatus);
        }

        // GET: Estatus/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstatusID,Clave,Descripcion,Estatus1,FechaHora")] Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estatus);
        }

        // GET: Estatus/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Estatus estatus = db.Estatus.Find(id);
            db.Estatus.Remove(estatus);
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
