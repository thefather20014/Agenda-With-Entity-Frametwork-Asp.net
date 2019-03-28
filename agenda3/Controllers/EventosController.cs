using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using agenda3;

namespace agenda3.Controllers
{
    public class EventosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Eventos
        public ActionResult Index()
        {
            var eventosSet = db.EventosSet.Include(e => e.Navegacion);
            return View(eventosSet.ToList());
        }

        public ActionResult Filtrar(String Fecha)
        {
            var filt = from s in db.EventosSet select s;
            if (!String.IsNullOrEmpty(Fecha))
            {
                filt = filt.Where(j => j.Fecha.ToString().Contains(Fecha));
            }

            return View(filt);
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.EventosSet.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.ModelFirstId1 = new SelectList(db.ModelFirstSet, "Id", "Nombre");
            return View();
        }

        // POST: Eventos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Evento,Fecha,Lugar,ModelFirstId,ModelFirstId1")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.EventosSet.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelFirstId1 = new SelectList(db.ModelFirstSet, "Id", "Nombre", eventos.ModelFirstId1);
            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.EventosSet.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelFirstId1 = new SelectList(db.ModelFirstSet, "Id", "Nombre", eventos.ModelFirstId1);
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evento,Fecha,Lugar,ModelFirstId,ModelFirstId1")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelFirstId1 = new SelectList(db.ModelFirstSet, "Id", "Nombre", eventos.ModelFirstId1);
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.EventosSet.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = db.EventosSet.Find(id);
            db.EventosSet.Remove(eventos);
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
