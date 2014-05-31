using Saturn.Model.Views;
using System.Data.Entity;

namespace Saturn.Data
{
    public partial class SaturnDbViewContext : DbContext
    {
        public SaturnDbViewContext()
            : base("name=SaturnDb")
        {
        }

        public virtual DbSet<ViewVehicles> ViewVehicles { get; set; }
        public virtual DbSet<ViewCandidates> ViewCandidates { get; set; }
        public virtual DbSet<ViewExaminations> ViewExaminations { get; set; }
        public virtual DbSet<ViewRegistrations> ViewRegistrations { get; set; }
        public virtual DbSet<ViewExamCandidates> ViewExamCandidates { get; set; }
        public virtual DbSet<ViewReqDocCandidates> ViewReqDocCandidates { get; set; }
        public virtual DbSet<ViewExamRegistration> ViewExamRegistration { get; set; }
        public virtual DbSet<ViewExamRegistrationError> ViewExamRegistrationError { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewCandidates>().Property(e => e.UniqueNumber).IsFixedLength();

            modelBuilder.Entity<ViewExamCandidates>().Property(e => e.ExamTime).HasPrecision(0);

            modelBuilder.Entity<ViewExaminations>().Property(e => e.ExamTime).HasPrecision(0);

            modelBuilder.Entity<ViewExamRegistration>().Property(e => e.UniqueNumber).IsFixedLength();
            modelBuilder.Entity<ViewExamRegistration>().Property(e => e.ExamTime).HasPrecision(0);

            modelBuilder.Entity<ViewRegistrations>().Property(e => e.UniqueNumber).IsFixedLength();
        }
    }
}
