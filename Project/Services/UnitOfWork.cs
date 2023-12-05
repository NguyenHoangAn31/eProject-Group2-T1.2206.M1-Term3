using Org.BouncyCastle.Asn1.Mozilla;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _db;

        public IApplicantRepository Applicant { get; private set; }
        public IApplicantVacancyRepository ApplicantVacancy { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IInterviewVacancyRepository InterviewVacancy { get; private set; }
        public IJobRepository Job { get; private set; }
        public IPositionRepository Position { get; private set; }
        public IVacancyJobRepository VacancyJob { get; private set; }
        public IVacancyRepository Vacancy { get; private set; }
        public IAppUserRepository AppUser { get; private set; }
        public IStatusVacancyRepository StatusVacancy { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Applicant = new ApplicantRepository(_db);
            ApplicantVacancy = new ApplicantVacancyRepository(_db);
            Department = new DepartmentRepository(_db);
            InterviewVacancy = new InterviewVacancyRepository(_db);
            Job = new JobRepository(_db);
            Position = new PositionRepository(_db);
            VacancyJob = new VacancyJobRepository(_db);
            Vacancy = new VacancyRepository(_db);
            AppUser = new AppUserRepository(_db); 
            StatusVacancy = new StatusVacancyRepository(_db);
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
