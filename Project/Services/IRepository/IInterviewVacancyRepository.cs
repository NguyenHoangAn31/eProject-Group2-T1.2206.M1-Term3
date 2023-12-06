using Project.Data;

namespace Project.Services.IRepository
{
    public interface IInterviewVacancyRepository : IRepository<InterviewVacancy>
    {
        Task<List<InterviewVacancy>> GetAllInterview();

        Task<InterviewVacancy> GetDetail();
    }
}
