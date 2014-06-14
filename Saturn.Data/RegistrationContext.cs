using Saturn.Model;
using Saturn.Model.Codebooks;
using Saturn.Model.Views;
using System.Data.Entity;

namespace Saturn.Data
{
    public class RegistrationContext : BaseContext<RegistrationContext>
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<ViewVehicles> Vehicles { get; set; }       
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<DrivingSchool> DrivingSchools { get; set; }
        public DbSet<DrivingCategory> DrivingCategories { get; set; }
        public DbSet<RegistrationStatus> RegistrationStatuses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<City>();
            modelBuilder.Ignore<ContactPerson>(); 
            modelBuilder.Ignore<PriceList>();
            modelBuilder.Ignore<ExamRegistration>();
            modelBuilder.Ignore<ReqDocDrivingCategory>();
            
            
        }
    }
}
