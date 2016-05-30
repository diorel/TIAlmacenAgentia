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
    public class DispositivoController : Controller
    {
        private InventarioTIEntities db = new InventarioTIEntities();

        // GET: Dispositivo
        public ActionResult Index()
        {
            var dispositivo = db.Dispositivo.Include(d => d.Asignacion).Include(d => d.Modelo);
            return View(dispositivo.ToList());
        }

        // GET: Dispositivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // GET: Dispositivo/Create
        public ActionResult Create()
        {
            ViewBag.DispositivoID = new SelectList(db.Asignacion, "AsignacionID", "UsuarioAlta");
            ViewBag.ModeloID = new SelectList(db.Modelo, "ModeloID", "Nombre");
            return View();
        }

        // POST: Dispositivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DispositivoID,ModeloID,NumeroSerie,Espesificaciones,FechaCompra,PrecioCompra,FechaHora")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Dispositivo.Add(dispositivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DispositivoID = new SelectList(db.Asignacion, "AsignacionID", "UsuarioAlta", dispositivo.DispositivoID);
            ViewBag.ModeloID = new SelectList(db.Modelo, "ModeloID", "Nombre", dispositivo.ModeloID);
            return View(dispositivo);
        }

        // GET: Dispositivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DispositivoID = new SelectList(db.Asignacion, "AsignacionID", "UsuarioAlta", dispositivo.DispositivoID);
            ViewBag.ModeloID = new SelectList(db.Modelo, "ModeloID", "Nombre", dispositivo.ModeloID);
            return View(dispositivo);
        }

        // POST: Dispositivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DispositivoID,ModeloID,NumeroSerie,Espesificaciones,FechaCompra,PrecioCompra,FechaHora")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DispositivoID = new SelectList(db.Asignacion, "AsignacionID", "UsuarioAlta", dispositivo.DispositivoID);
            ViewBag.ModeloID = new SelectList(db.Modelo, "ModeloID", "Nombre", dispositivo.ModeloID);
            return View(dispositivo);
        }

        // GET: Dispositivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // POST: Dispositivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispositivo dispositivo = db.Dispositivo.Find(id);
            db.Dispositivo.Remove(dispositivo);
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
