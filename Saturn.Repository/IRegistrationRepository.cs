using Saturn.Model;
using Saturn.Model.Views;
using System;
using System.Collections.Generic;

namespace Saturn.Repository
{
    public interface IRegistrationRepository : IDisposable
    {
        IEnumerable<ViewRegistrations> SelectAll();
        ViewRegistrations SelectByID(int id);
        void Insert(Registration obj);
        void Update(Registration obj);
        void Delete(string id);
        void Save();
    }
}
