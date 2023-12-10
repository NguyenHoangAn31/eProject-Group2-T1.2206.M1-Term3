using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Reflection.Emit;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
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
            //builder.Entity<VacancyJob>()
            //    .HasOne(v => v.Vacancy)
            //    .WithMany()
            //    .HasForeignKey(v => v.Vacancy_Id)
            //    .OnDelete(DeleteBehavior.Cascade);      


            //builder.Entity<ApplicantVacancy>()
            //    .HasOne(a => a.Vacancy)
            //    .WithMany()
            //    .HasForeignKey(a => a.Vacancy_Id)
            //    .OnDelete(DeleteBehavior.Cascade);
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
        public DbSet<Department>? Departments { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Applicant>? Applicants { get; set; }
        public DbSet<Skill>? Skills { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<StatusApplicant>? StatusApplicants { get; set; }
        public DbSet<StatusVacancy>? StatusVacancies { get; set;}
        public DbSet<StatusInterview>? StatusInterviews { get; set; }
        public DbSet<Vacancy>? Vacancies { get; set; }
        public DbSet<VacancySkill>? VacanciesSkills { get; set; }
        public DbSet<ApplicantVacancy>? ApplicantsVacancies { get; set; }
        public DbSet<InterviewVacancy>? InterviewsVacancies { get; set; }
    }
}