namespace Project.Services.IRepository
{
    public interface IUnitOfWork
    {
        IApplicantRepository Applicant { get; }
        IApplicantVacancyRepository ApplicantVacancy { get; }
        IDepartmentRepository Department { get; }
        IInterviewVacancyRepository InterviewVacancy { get; }
        ISkillRepository Skill { get; }
        IPositionRepository Position { get; }
        IVacancySkillRepository VacancyJob { get; }
        IVacancyRepository Vacancy { get; }
        IAppUserRepository AppUser { get; }
        IStatusVacancyRepository StatusVacancy { get; }
        Task Save();
    }
}
