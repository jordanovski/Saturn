using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model;
using Saturn.Model.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class ReqDocCandidateController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        // GET: /ReqDocCandidate/
        public ActionResult Index(int Id = 0)
        {
            Session["CandidateId"] = Id;
            return View();
        }
        
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;

            int candidateId = int.Parse(Session["CandidateId"].ToString());
            var reqdoccandidates = db.ReqDocCandidate.Where(w => w.CandidateId == candidateId).Select(ReqDocCandidateViewModel.FromReqDocCandidate).ToList();
            return Json(reqdoccandidates.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ReqDocCandidate reqDocCandidate)
        {
            if (reqDocCandidate != null && ModelState.IsValid)
            {
                db.ReqDocCandidate.Add(reqDocCandidate);
                db.SaveChanges();
            }

            return Json(new[] { reqDocCandidate }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReqDocCandidateViewModel> reqDocCandidate)
        {
            // Will keep the updated entitites here. Used to return the result later.
            var entities = new List<ReqDocCandidate>();
            if (ModelState.IsValid)
            {
                //using (var northwind = new NorthwindEntities())
                //{
                foreach (var d in reqDocCandidate)
                {
                    // Create a new Product entity and set its properties from the posted ProductViewModel
                    var entity = new ReqDocCandidate
                    {
                        Id = d.Id,
                        CandidateId = d.CandidateId,
                        ReqDocumentId = d.ReqDocumentId,
                        DocumentNumber = d.DocumentNumber,
                        IssueDate = d.IssueDate,
                        ValidTo = d.ValidTo,
                        Note = d.Note
                    };
                    // Store the entity for later use
                    entities.Add(entity);
                    // Attach the entity
                    db.ReqDocCandidate.Attach(entity);
                    // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
                    db.Entry(entity).State = EntityState.Modified;
                    // Or use ObjectStateManager if using a previous version of Entity Framework
                    // northwind.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                // Update the entities in the database
                db.SaveChanges();
                //}
            }
            // Return the updated entities. Also return any validation errors.
            return Json(reqDocCandidate.ToDataSourceResult(request, ModelState));
        }
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Update([DataSourceRequest] DataSourceRequest request, ReqDocCandidate reqDocCandidate)
        //{
        //    if (reqDocCandidate != null && ModelState.IsValid)
        //    {
        //        db.Entry(reqDocCandidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }

        //    return Json(new[] { reqDocCandidate }.ToDataSourceResult(request, ModelState));
        //}


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, ReqDocCandidate reqDocCandidate)
        {
            if (reqDocCandidate != null)
            {
                db.ReqDocCandidate.Remove(reqDocCandidate);
                db.SaveChanges();
            }

            return Json(new[] { reqDocCandidate }.ToDataSourceResult(request, ModelState));
        }




        // GET: /ReqDocCandidate/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocCandidate reqdoccandidate = await db.ReqDocCandidate.FindAsync(id);
            if (reqdoccandidate == null)
            {
                return HttpNotFound();
            }
            return View(reqdoccandidate);
        }

        // GET: /ReqDocCandidate/Create
        public ActionResult Create()
        {
            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument");
            return View();
        }

        // POST: /ReqDocCandidate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReqDocumentId,CandidateId,DocumentNumber,IssueDate,ValidTo,Note")] ReqDocCandidate reqdoccandidate)
        {
            if (ModelState.IsValid)
            {
                db.ReqDocCandidate.Add(reqdoccandidate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument", reqdoccandidate.ReqDocumentId);
            return View(reqdoccandidate);
        }

        // GET: /ReqDocCandidate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocCandidate reqdoccandidate = await db.ReqDocCandidate.FindAsync(id);
            if (reqdoccandidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument", reqdoccandidate.ReqDocumentId);
            return View(reqdoccandidate);
        }

        // POST: /ReqDocCandidate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReqDocumentId,CandidateId,DocumentNumber,IssueDate,ValidTo,Note")] ReqDocCandidate reqdoccandidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reqdoccandidate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument", reqdoccandidate.ReqDocumentId);
            return View(reqdoccandidate);
        }

        // GET: /ReqDocCandidate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocCandidate reqdoccandidate = await db.ReqDocCandidate.FindAsync(id);
            if (reqdoccandidate == null)
            {
                return HttpNotFound();
            }
            return View(reqdoccandidate);
        }

        // POST: /ReqDocCandidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReqDocCandidate reqdoccandidate = await db.ReqDocCandidate.FindAsync(id);
            db.ReqDocCandidate.Remove(reqdoccandidate);
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