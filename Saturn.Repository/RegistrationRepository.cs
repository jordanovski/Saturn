using Saturn.Data;
using Saturn.Model;
using Saturn.Model.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Saturn.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly SaturnDbContext db = null;
        private readonly SaturnDbViewContext dbView = null;
        
        public RegistrationRepository()
        {
            this.db = new SaturnDbContext();
            this.dbView = new SaturnDbViewContext();
        }
        public RegistrationRepository(SaturnDbContext db)
        {
            this.db = db;
            this.dbView = new SaturnDbViewContext();
        }
        public RegistrationRepository(SaturnDbViewContext dbView)
        {
            this.db = new SaturnDbContext();
            this.dbView = dbView;
        }
        public RegistrationRepository(SaturnDbContext db, SaturnDbViewContext dbView)
        {
            this.db = db;
            this.dbView = dbView;
        }


        public IEnumerable<ViewRegistrations> SelectAll()
        {
            return dbView.ViewRegistrations.OrderByDescending(o => o.RegistrationDate).ToList();
        }

        public ViewRegistrations SelectByID(int id)
        {
            return dbView.ViewRegistrations.First(f => f.RegistrationId == id);
        }

        public void Insert(Registration obj)
        {
            db.Registration.Add(obj);
        }

        public void Update(Registration obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Registration existing = db.Registration.Find(id);
            db.Registration.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    dbView.Dispose();
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
