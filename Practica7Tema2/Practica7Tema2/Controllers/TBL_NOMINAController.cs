using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Models;

namespace Practica7Tema2.Controllers
{
    public class TBL_NOMINAController : Controller
    {
        private ConsecionBarrancaEntities db = new ConsecionBarrancaEntities();

        // GET: TBL_NOMINA
        public ActionResult Index()
        {
            return View(db.TBL_NOMINA.ToList());
        }

        // GET: TBL_NOMINA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_NOMINA tBL_NOMINA = db.TBL_NOMINA.Find(id);
            if (tBL_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_NOMINA);
        }

        // GET: TBL_NOMINA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_NOMINA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,CEDULA,NOMBRE,CARGO,SUELDO")] TBL_NOMINA tBL_NOMINA)
        {
            if (ModelState.IsValid)
            {
                db.TBL_NOMINA.Add(tBL_NOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_NOMINA);
        }

        // GET: TBL_NOMINA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_NOMINA tBL_NOMINA = db.TBL_NOMINA.Find(id);
            if (tBL_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_NOMINA);
        }

        // POST: TBL_NOMINA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,CEDULA,NOMBRE,CARGO,SUELDO")] TBL_NOMINA tBL_NOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_NOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_NOMINA);
        }

        // GET: TBL_NOMINA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_NOMINA tBL_NOMINA = db.TBL_NOMINA.Find(id);
            if (tBL_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_NOMINA);
        }

        // POST: TBL_NOMINA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_NOMINA tBL_NOMINA = db.TBL_NOMINA.Find(id);
            db.TBL_NOMINA.Remove(tBL_NOMINA);
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
