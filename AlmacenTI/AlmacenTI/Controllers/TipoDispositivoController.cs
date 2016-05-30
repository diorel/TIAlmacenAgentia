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
    public class TipoDispositivoController : Controller
    {
        private InventarioTIEntities db = new InventarioTIEntities();

        // GET: TipoDispositivo
        public ActionResult Index()
        {
            return View(db.TipoDispositivo.ToList());
        }

        // GET: TipoDispositivo/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDispositivo tipoDispositivo = db.TipoDispositivo.Find(id);
            if (tipoDispositivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDispositivo);
        }

        // GET: TipoDispositivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDispositivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDispositivoID,Clave,Descripcion,Estatus,FechaHora")] TipoDispositivo tipoDispositivo)
        {
            if (ModelState.IsValid)
            {
                db.TipoDispositivo.Add(tipoDispositivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDispositivo);
        }

        // GET: TipoDispositivo/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDispositivo tipoDispositivo = db.TipoDispositivo.Find(id);
            if (tipoDispositivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDispositivo);
        }

        // POST: TipoDispositivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDispositivoID,Clave,Descripcion,Estatus,FechaHora")] TipoDispositivo tipoDispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDispositivo);
        }

        // GET: TipoDispositivo/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDispositivo tipoDispositivo = db.TipoDispositivo.Find(id);
            if (tipoDispositivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoDispositivo);
        }

        // POST: TipoDispositivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            TipoDispositivo tipoDispositivo = db.TipoDispositivo.Find(id);
            db.TipoDispositivo.Remove(tipoDispositivo);
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
