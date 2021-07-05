using Newtonsoft.Json;
using ProvaCandidato.Data;
using ProvaCandidato.Helper;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class BaseController<T> : Controller where T: class
    {
        protected readonly ContextoPrincipal db = new ContextoPrincipal();

        // GET: T
        public virtual ActionResult Index()
        {
            return View(db.Set<T>().ToList());
        }

        // GET: T/Details/5
        public virtual ActionResult Details(int? id)
        {
            return GetActionResultById(id);
        }

        // GET: T/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // GET: T/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            return GetActionResultById(id);
        }

        // GET: T/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            return GetActionResultById(id);
        }

        // POST: T/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            MessageHelper.DisplaySuccessMessage(this, $"Objeto {id} deletado com sucesso.");
            T obj = db.Set<T>().Find(id);
            db.Set<T>().Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected ActionResult GetActionResultById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T obj = GetObjectById(id);

            if (obj == null)
            {
                return HttpNotFound();
            }
            JsonSerializerSettings converter = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(obj, converter);

            TempData[typeof(T).Name] = json;
            return View(obj);
        }

        protected T GetObjectById(int? id)
        {
            return db.Set<T>().Find(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(T obj)
        {
            if (ModelState.IsValid)
            {
                MessageHelper.DisplaySuccessMessage(this, $"Objeto atualizado com sucesso.");
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(T obj)
        {
            if (ModelState.IsValid)
            {
                MessageHelper.DisplaySuccessMessage(this, $"Objeto criado com sucesso.");
                db.Set<T>().Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
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