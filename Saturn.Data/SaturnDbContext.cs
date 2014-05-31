namespace Saturn.Data
{
    using Saturn.Model;
    using Saturn.Model.Codebooks;
    using System.Data.Entity;

    public partial class SaturnDbContext : DbContext
    {
        public SaturnDbContext()
            : base("name=SaturnDb")
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContactPerson> ContactPerson { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<DrivingCategory> DrivingCategory { get; set; }
        public virtual DbSet<DrivingSchool> DrivingSchool { get; set; }
        public virtual DbSet<ErrorType> ErrorType { get; set; }
        public virtual DbSet<ExamCenters> ExamCenters { get; set; }
        public virtual DbSet<Examination> Examination { get; set; }
        public virtual DbSet<Examiner> Examiner { get; set; }
        public virtual DbSet<ExamLanguage> ExamLanguage { get; set; }
        public virtual DbSet<ExamRegistration> ExamRegistration { get; set; }
        public virtual DbSet<ExamRegistrationError> ExamRegistrationError { get; set; }
        public virtual DbSet<ExamRegistrationStatus> ExamRegistrationStatus { get; set; }
        public virtual DbSet<ExamType> ExamType { get; set; }
        public virtual DbSet<ExamWayOfTaking> ExamWayOfTaking { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<PriceList> PriceList { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReqDocCandidate> ReqDocCandidate { get; set; }
        public virtual DbSet<ReqDocDrivingCategory> ReqDocDrivingCategory { get; set; }
        public virtual DbSet<RequiredDocument> RequiredDocument { get; set; }
        public virtual DbSet<Rescheduling> Rescheduling { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleBrand> VehicleBrand { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().Property(e => e.UniqueNumber).IsFixedLength();

            modelBuilder.Entity<City>().HasMany(e => e.ExamCenters).WithRequired(e => e.City).WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactType>().HasMany(e => e.ContactPerson).WithRequired(e => e.ContactType).WillCascadeOnDelete(false);

            modelBuilder.Entity<DrivingCategory>().HasMany(e => e.PriceList).WithRequired(e => e.DrivingCategory).WillCascadeOnDelete(false);
            modelBuilder.Entity<DrivingCategory>().HasMany(e => e.ReqDocDrivingCategory).WithRequired(e => e.DrivingCategory).WillCascadeOnDelete(false);

            modelBuilder.Entity<DrivingSchool>().Property(e => e.TaxNumber).IsFixedLength();
            modelBuilder.Entity<DrivingSchool>().HasMany(e => e.Instructor).WithRequired(e => e.DrivingSchool).WillCascadeOnDelete(false);

            modelBuilder.Entity<ErrorType>().HasMany(e => e.ExamRegistrationError).WithRequired(e => e.ErrorType).WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamCenters>().Property(e => e.TaxNumber).IsFixedLength();
            modelBuilder.Entity<ExamCenters>().HasMany(e => e.Examination).WithRequired(e => e.ExamCenters).HasForeignKey(e => e.ExamCenterId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Examination>().Property(e => e.ExamTime).HasPrecision(0);
            modelBuilder.Entity<Examination>().HasMany(e => e.ExamRegistration).WithOptional(e => e.Examination).HasForeignKey(e => e.ExamTypeId);

            modelBuilder.Entity<Examiner>().HasMany(e => e.Examination).WithOptional(e => e.Examiner).HasForeignKey(e => e.PresidentId);
            modelBuilder.Entity<Examiner>().HasMany(e => e.Examination1).WithOptional(e => e.Examiner1).HasForeignKey(e => e.ExaminerId);
            modelBuilder.Entity<Examiner>().HasMany(e => e.Examination2).WithOptional(e => e.Examiner2).HasForeignKey(e => e.MemberId);

            modelBuilder.Entity<ExamLanguage>().HasMany(e => e.ExamRegistration).WithOptional(e => e.ExamLanguage).HasForeignKey(e => e.LanguageId);

            modelBuilder.Entity<ExamRegistration>().HasMany(e => e.ExamRegistrationError).WithRequired(e => e.ExamRegistration).WillCascadeOnDelete(false);
            modelBuilder.Entity<ExamRegistration>().HasMany(e => e.Rescheduling).WithRequired(e => e.ExamRegistration).WillCascadeOnDelete(false);
            modelBuilder.Entity<ExamRegistration>().HasMany(e => e.Report).WithRequired(e => e.ExamRegistration).WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamRegistrationStatus>().HasMany(e => e.ExamRegistration).WithOptional(e => e.ExamRegistrationStatus).HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<ExamType>().HasMany(e => e.PriceList).WithRequired(e => e.ExamType).WillCascadeOnDelete(false);

            modelBuilder.Entity<Instructor>().Property(e => e.UniqueNumber).IsFixedLength();
            modelBuilder.Entity<Instructor>().HasMany(e => e.Registration).WithOptional(e => e.Instructor).HasForeignKey(e => e.InstructorPracticeId);
            modelBuilder.Entity<Instructor>().HasMany(e => e.Registration1).WithOptional(e => e.Instructor1).HasForeignKey(e => e.InstructorTheoryId);

            modelBuilder.Entity<RegistrationStatus>().HasMany(e => e.Registration).WithOptional(e => e.RegistrationStatus).HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<Report>().Property(e => e.TestNumber).IsFixedLength();
            modelBuilder.Entity<Report>().Property(e => e.Status).IsFixedLength();

            modelBuilder.Entity<RequiredDocument>().HasMany(e => e.ReqDocCandidate).WithRequired(e => e.RequiredDocument).HasForeignKey(e => e.ReqDocumentId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RequiredDocument>().HasMany(e => e.ReqDocDrivingCategory).WithRequired(e => e.RequiredDocument).HasForeignKey(e => e.ReqDocumentId).WillCascadeOnDelete(false);

        }
    }
}
