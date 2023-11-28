using Project.Data;

namespace Project.Services.IRepository
{
    public interface IApplicantVacancyRepository : IRepository<ApplicantVacancy>
    {
        Task<string?> CheckExistApplicantVacancy(int applicantid , string vacancyid);
    }
}
