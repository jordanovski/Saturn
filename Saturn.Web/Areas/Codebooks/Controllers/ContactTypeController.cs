﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class ContactTypeController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.ContactType.OrderBy(o => o.Type).ToList();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = await db.ContactType.FindAsync(id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type")] ContactType contacttype)
        {
            if (ModelState.IsValid)
            {
                db.ContactType.Add(contacttype);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contacttype);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = await db.ContactType.FindAsync(id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type")] ContactType contacttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacttype).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacttype);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = await db.ContactType.FindAsync(id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactType contacttype = await db.ContactType.FindAsync(id);
            db.ContactType.Remove(contacttype);
            await db.SaveChangesAsync();
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