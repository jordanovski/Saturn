using Saturn.Data;
using Saturn.Model;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly SaturnDbContext db = null;

        public CandidateRepository()
        {
            this.db = new SaturnDbContext();
        }
        public CandidateRepository(SaturnDbContext db)
        {
            this.db = db;
        }


        public async Task<List<CandidateViewModel>> SelectAll()
        {
            return await db.Candidate
                .Include(c => c.City)
                .Include(c => c.DrivingCategory)
                .Include(c => c.ExistingDrivingCategory)
                .OrderByDescending(o => o.Id)
                .Select(CandidateViewModel.FromCandidates).ToListAsync();
        }

        public Candidate SelectByID(string id)
        {
            return db.Candidate.Find(id);
        }

        public void Insert(Candidate obj)
        {
            db.Candidate.Add(obj);
        }

        public void Update(Candidate obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Candidate existing = db.Candidate.Find(id);
            db.Candidate.Remove(existing);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
