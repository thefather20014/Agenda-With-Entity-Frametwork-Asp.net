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
    public class ModelFirstsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        public ActionResult Menu()
        {
            return View(db.ModelFirstSet.ToList());
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        // GET: ModelFirsts
        public ActionResult Index()
        {
            return View(db.ModelFirstSet.ToList());
        }

        public ActionResult Filtrar(String Nombre)
        {
            var filt = from s in db.ModelFirstSet select s;
            if (!String.IsNullOrEmpty(Nombre))
            {
                filt = filt.Where(j => j.Nombre.Contains(Nombre));
            }

            return View(filt);
        }

        // GET: ModelFirsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelFirst modelFirst = db.ModelFirstSet.Find(id);
            if (modelFirst == null)
            {
                return HttpNotFound();
            }
            return View(modelFirst);
        }

        // GET: ModelFirsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelFirsts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Telefono,Direccion")] ModelFirst modelFirst)
        {
            if (ModelState.IsValid)
            {
                db.ModelFirstSet.Add(modelFirst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelFirst);
        }

        // GET: ModelFirsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelFirst modelFirst = db.ModelFirstSet.Find(id);
            if (modelFirst == null)
            {
                return HttpNotFound();
            }
            return View(modelFirst);
        }

        // POST: ModelFirsts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Telefono,Direccion")] ModelFirst modelFirst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelFirst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelFirst);
        }

        // GET: ModelFirsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelFirst modelFirst = db.ModelFirstSet.Find(id);
            if (modelFirst == null)
            {
                return HttpNotFound();
            }
            return View(modelFirst);
        }

        // POST: ModelFirsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelFirst modelFirst = db.ModelFirstSet.Find(id);
            db.ModelFirstSet.Remove(modelFirst);
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
