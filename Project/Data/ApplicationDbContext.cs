using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // cắt chuỗi AspNet trước tên của table 
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tblName = entityType.GetTableName();
                if (tblName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tblName.Substring(6));
                }
            }
            builder.Entity<Department>().HasData(
                new Department { Department_Id = "D0001", Name = "Information Technology" , Created_at = DateTime.Now},
                new Department { Department_Id = "D0002", Name = "Desgin" , Created_at = DateTime.Now },
                new Department { Department_Id = "D0003", Name = "Marketing" , Created_at = DateTime.Now }
                );
            builder.Entity<Applicant>().HasData(
                new Applicant { Id = 1, Email = "user1@example.com", Password = "Abc12345678", Fullname = "James Smith", Phone = "1234567890", Birthday = new DateTime(1990, 5, 10), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "Westminster", District = "City of Westminster", Province = "Greater London" , Created_at = DateTime.Now},
                new Applicant { Id = 2, Email = "user2@example.com", Password = "Abc12345678", Fullname = "Sarah Johnson", Phone = "2345678901", Birthday = new DateTime(1995, 8, 15), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "City Centre", District = "Manchester City", Province = "Greater Manchester" , Created_at = DateTime.Now },
                new Applicant { Id = 3, Email = "user3@example.com", Password = "Abc12345678", Fullname = "David Williams", Phone = "3456789012", Birthday = new DateTime(1985, 3, 20), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "Ladywood", District = "Birmingham City Centre", Province = "West Midlands" , Created_at = DateTime.Now },
                new Applicant { Id = 4, Email = "user4@example.com", Password = "Abc12345678", Fullname = "Emma Brown", Phone = "4567890123", Birthday = new DateTime(1980, 12, 25), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "Riverside", District = "Liverpool City Centre", Province = "Merseyside" , Created_at = DateTime.Now },
                new Applicant { Id = 5, Email = "user5@example.com", Password = "Abc12345678", Fullname = "John Jones", Phone = "5678901234", Birthday = new DateTime(1992, 6, 30), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "City Centre", District = "Leeds City Centre", Province = "West Yorkshire" , Created_at = DateTime.Now },
                new Applicant { Id = 6, Email = "user6@example.com", Password = "Abc12345678", Fullname = "Lucy Taylor", Phone = "6789012345", Birthday = new DateTime(1978, 9, 5), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "Central", District = "Bristol City Centre", Province = "Bristol" , Created_at = DateTime.Now },
                new Applicant { Id = 7, Email = "user7@example.com", Password = "Abc12345678", Fullname = "Michael Davies", Phone = "7890123456", Birthday = new DateTime(1988, 11, 12), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "City Centre", District = "Sheffield City Centre", Province = "South Yorkshire" , Created_at = DateTime.Now },
                new Applicant { Id = 8, Email = "user8@example.com", Password = "Abc12345678", Fullname = "Olivia Wilson", Phone = "8901234567", Birthday = new DateTime(1998, 4, 18), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "Ouseburn", District = "Newcastle City Centre", Province = "Tyne and Wear" , Created_at = DateTime.Now },
                new Applicant { Id = 9, Email = "user9@example.com", Password = "Abc12345678", Fullname = "Thomas Evans", Phone = "9012345678", Birthday = new DateTime(1983, 7, 22), Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png", Ward = "Bridge", District = "Nottingham City Centre", Province = "Nottinghamshire" , Created_at = DateTime.Now }
                );
            builder.Entity<Job>().HasData(
                new Job { Id = 1 , Department_Id = "D0001", Name = "C#" , Created_at = DateTime.Now },
                new Job { Id = 2 , Department_Id = "D0001", Name = "Java" , Created_at = DateTime.Now },
                new Job { Id = 3 , Department_Id = "D0001", Name = "PHP" , Created_at = DateTime.Now },
                new Job { Id = 4 , Department_Id = "D0002", Name = "Adobe Creative Suite" , Created_at = DateTime.Now },
                new Job { Id = 5 , Department_Id = "D0002", Name = "Sketch" , Created_at = DateTime.Now },
                new Job { Id = 6 , Department_Id = "D0002", Name = "Figma" , Created_at = DateTime.Now },
                new Job { Id = 7 , Department_Id = "D0003", Name = "Google Analytics" , Created_at = DateTime.Now },
                new Job { Id = 8 , Department_Id = "D0003", Name = "SEO" , Created_at = DateTime.Now },
                new Job { Id = 9 , Department_Id = "D0003", Name = "Google AdWords , Facebook Ads" , Created_at = DateTime.Now }
                );
            builder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Intern" , Created_at = DateTime.Now },
                new Position { Id = 2, Name = "Fresher" , Created_at = DateTime.Now },
                new Position { Id = 3, Name = "Junior" , Created_at = DateTime.Now },
                new Position { Id = 4, Name = "Senior" , Created_at = DateTime.Now },
                new Position { Id = 5, Name = "Leader" , Created_at = DateTime.Now }
                );
            builder.Entity<StatusApplicant>().HasData(
                new StatusApplicant { Id = 1, Name = "Not Process" , Created_at = DateTime.Now },
                new StatusApplicant { Id = 2, Name = "In Process" , Created_at = DateTime.Now },
                new StatusApplicant { Id = 3, Name = "Hired" , Created_at = DateTime.Now },
                new StatusApplicant { Id = 4, Name = "Banned" , Created_at = DateTime.Now }
                );
            builder.Entity<StatusVacancy>().HasData(
                  new StatusVacancy { Id = 1, Name = "Open" , Created_at = DateTime.Now},
                  new StatusVacancy { Id = 2, Name = "Close" , Created_at = DateTime.Now },
                  new StatusVacancy { Id = 3, Name = "Suspended" , Created_at = DateTime.Now }
                );
            builder.Entity<StatusInterview>().HasData(
                new StatusInterview { Id = 1, Name = "Processing" , Created_at = DateTime.Now },
                new StatusInterview { Id = 2, Name = "Scheduled" , Created_at = DateTime.Now },
                new StatusInterview { Id = 3, Name = "Selected" , Created_at = DateTime.Now },
                new StatusInterview { Id = 4, Name = "Rejected" , Created_at = DateTime.Now }
                );
            builder.Entity<Vacancy>().HasData(
                new Vacancy { Vacancy_Id = "V0001" , Hr_Id = null , Position_Id = 1 , StatusVacancy_Id = 1 , Quantity = 5 , Salary = 2000 , Place = "America" , Title = "Title" , Requirement = "Requirement" , Description = "Description" , Benefits = "Benefits" , EndDate = DateTime.Now.AddDays(10) , Created_at = DateTime.Now},
                new Vacancy { Vacancy_Id = "V0002" , Hr_Id = null , Position_Id = 2 , StatusVacancy_Id = 1 , Quantity = 4 , Salary = 7000 , Place = "America" , Title = "Title" , Requirement = "Requirement" , Description = "Description" , Benefits = "Benefits" , EndDate = DateTime.Now.AddDays(10) , Created_at = DateTime.Now},
                new Vacancy { Vacancy_Id = "V0003" , Hr_Id = null , Position_Id = 3 , StatusVacancy_Id = 1 , Quantity = 3 , Salary = 10000 , Place = "America" , Title = "Title" , Requirement = "Requirement" , Description = "Description" , Benefits = "Benefits" , EndDate = DateTime.Now.AddDays(10) , Created_at = DateTime.Now},
                new Vacancy { Vacancy_Id = "V0004" , Hr_Id = null , Position_Id = 4 , StatusVacancy_Id = 1 , Quantity = 2 , Salary = 13000 , Place = "America" , Title = "Title" , Requirement = "Requirement" , Description = "Description" , Benefits = "Benefits" , EndDate = DateTime.Now.AddDays(10) , Created_at = DateTime.Now},
                new Vacancy { Vacancy_Id = "V0005" , Hr_Id = null , Position_Id = 5 , StatusVacancy_Id = 1 , Quantity = 1 , Salary = 15000 , Place = "America" , Title = "Title" , Requirement = "Requirement" , Description = "Description" , Benefits = "Benefits" , EndDate = DateTime.Now.AddDays(10) , Created_at = DateTime.Now}
                );
            builder.Entity<VacancyJob>().HasData(
                new VacancyJob { Id = 1, Vacancy_Id = "V0001", Job_Id = 1, Created_at = DateTime.Now },
                new VacancyJob { Id = 2, Vacancy_Id = "V0001", Job_Id = 2, Created_at = DateTime.Now },
                new VacancyJob { Id = 3, Vacancy_Id = "V0001", Job_Id = 3, Created_at = DateTime.Now },
                new VacancyJob { Id = 4, Vacancy_Id = "V0002", Job_Id = 4, Created_at = DateTime.Now },
                new VacancyJob { Id = 5, Vacancy_Id = "V0002", Job_Id = 5, Created_at = DateTime.Now },
                new VacancyJob { Id = 6, Vacancy_Id = "V0002", Job_Id = 6, Created_at = DateTime.Now },
                new VacancyJob { Id = 7, Vacancy_Id = "V0003", Job_Id = 7, Created_at = DateTime.Now },
                new VacancyJob { Id = 8, Vacancy_Id = "V0003", Job_Id = 8, Created_at = DateTime.Now },
                new VacancyJob { Id = 9, Vacancy_Id = "V0003", Job_Id = 9, Created_at = DateTime.Now },
                new VacancyJob { Id = 10, Vacancy_Id = "V0004", Job_Id = 1, Created_at = DateTime.Now },
                new VacancyJob { Id = 11, Vacancy_Id = "V0004", Job_Id = 2, Created_at = DateTime.Now },
                new VacancyJob { Id = 12, Vacancy_Id = "V0004", Job_Id = 3, Created_at = DateTime.Now },
                new VacancyJob { Id = 13, Vacancy_Id = "V0005", Job_Id = 4, Created_at = DateTime.Now },
                new VacancyJob { Id = 14, Vacancy_Id = "V0005", Job_Id = 5, Created_at = DateTime.Now },
                new VacancyJob { Id = 15, Vacancy_Id = "V0005", Job_Id = 6, Created_at = DateTime.Now }
                );
            builder.Entity<ApplicantVacancy>().HasData(
                new ApplicantVacancy { ApplicantVacancy_Id = "A0001", Vacancy_Id = "V0001", Applicant_Id = 1, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0002", Vacancy_Id = "V0002", Applicant_Id = 2, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0003", Vacancy_Id = "V0003", Applicant_Id = 3, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0004", Vacancy_Id = "V0004", Applicant_Id = 4, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0005", Vacancy_Id = "V0005", Applicant_Id = 5, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0006", Vacancy_Id = "V0001", Applicant_Id = 6, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0007", Vacancy_Id = "V0002", Applicant_Id = 7, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0008", Vacancy_Id = "V0003", Applicant_Id = 8, StatusApplicant_Id = 1, Created_at = DateTime.Now },
                new ApplicantVacancy { ApplicantVacancy_Id = "A0009", Vacancy_Id = "V0004", Applicant_Id = 9, StatusApplicant_Id = 1, Created_at = DateTime.Now }
                );
            builder.Entity<InterviewVacancy>().HasData(
                new InterviewVacancy { Id = 1, ApplicantVacancy_Id = "A0001", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 2, ApplicantVacancy_Id = "A0002", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 3, ApplicantVacancy_Id = "A0003", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 4, ApplicantVacancy_Id = "A0004", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 5, ApplicantVacancy_Id = "A0001", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 6, ApplicantVacancy_Id = "A0002", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 7, ApplicantVacancy_Id = "A0003", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 8, ApplicantVacancy_Id = "A0004", StatusInterview_Id = 1, Created_at = DateTime.Now },
                new InterviewVacancy { Id = 9, ApplicantVacancy_Id = "A0005", StatusInterview_Id = 1, Created_at = DateTime.Now }
                );
         


        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.Updated_at = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("Created_at").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.Created_at = utcNow;
                            trackable.Updated_at = utcNow;
                            break;
                    }
                }
            }
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<StatusApplicant> StatusApplicants { get; set; }
        public DbSet<StatusVacancy> StatusVacancy { get; set;}
        public DbSet<StatusInterview> StatusInterviews { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyJob> VacanciesJobs { get; set; }
        public DbSet<ApplicantVacancy> ApplicantsDetail { get; set; }
        public DbSet<InterviewVacancy> ApplicantsVacnacies { get; set; }
    }
}