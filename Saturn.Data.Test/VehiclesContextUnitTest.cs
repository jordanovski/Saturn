using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;

namespace Saturn.Data.Test
{
    [TestClass]
    public class VehiclesContextUnitTest
    {
        [TestMethod]
        public void VehiclesContextHasFiveEntitiesInModel()
        {
            using (var context = new VehiclesContext())
            {
                var oc = (context as IObjectContextAdapter).ObjectContext;
                foreach (var entity in oc.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace).ToList())
                {
                    Debug.WriteLine(entity.FullName);
                }
                Assert.IsTrue(oc.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace).Count == 5);
            }
        }
    }
}
