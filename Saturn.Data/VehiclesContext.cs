using Saturn.Model.Codebooks;
using Saturn.Model.Views;
using System.Data.Entity;

namespace Saturn.Data
{
    public class VehiclesContext : BaseContext<VehiclesContext>
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<DrivingSchool> DrivingSchools { get; set; }
        public DbSet<ViewVehicles> VehiclesView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ContactPerson>();
            modelBuilder.Ignore<Instructor>();
            modelBuilder.Ignore<City>();
        }
    }
}
