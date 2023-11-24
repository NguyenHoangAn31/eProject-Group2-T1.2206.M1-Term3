namespace Project.Services.IRepository
{
    public interface IUnitOfWork
    {
        IApplicantRepository Applicant { get; }
        IApplicantVacancyRepository ApplicantVacancy { get; }
        IDepartmentRepository Department { get; }
        IInterviewVacancyRepository InterviewVacancy { get; }
        IJobRepository Job { get; }
        IPositionRepository Position { get; }
        IVacancyJobRepository VacancyJob { get; }
        IVacancyRepository Vacancy { get; }
        IAppUserRepository AppUser { get; }
        Task Save();
    }
}
