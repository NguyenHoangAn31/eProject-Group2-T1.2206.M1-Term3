using Project.Data;

namespace Project.Services.IRepository
{
    public interface IApplicantVacancyRepository : IRepository<ApplicantVacancy>
    {
        Task<ApplicantVacancy?> CheckExistApplicantVacancy(int applicantid , string vacancyid);
        Task<ApplicantVacancy?> GetDetail(int? id);
    }
}
