using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saturn.Data.Test
{
    [TestClass]
    public class SaturnDbContextUnitTest
    {
        [TestMethod]
        public void CanCreateSaturnDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SaturnDbContext>());
            using (var context = new SaturnDbContext())
            {
                Assert.AreEqual(0, context.Candidate.Count());
            }
        }
    }
}
