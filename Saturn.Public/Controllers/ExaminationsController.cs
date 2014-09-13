using System.Threading.Tasks;
using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saturn.WebPublic.Controllers
{
    public class ExaminationsController : Controller
    {
        private readonly IPublicRepository repository;
        //private readonly SaturnDbContext db = new SaturnDbContext();
        //private readonly SaturnDbViewContext dbView = new SaturnDbViewContext();

        public ExaminationsController()
        {
            this.repository = new PublicRepository(new SaturnDbContext(),new SaturnDbViewContext());
        }

        public async Task<ActionResult> FinishedExams()
        {
            var data = await repository.GetFinishedExamsAsync();
            return View(data);
        }

        public async Task<ActionResult> UpcomingExams()
        {
            var data = await repository.GetUpcomingExamAsync();
            return View(data);
        }
    }
}