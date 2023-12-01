using Project.Data;

namespace Project.Services.IRepository
{
    public interface IVacancyRepository : IRepository<Vacancy>
    {
        Task<List<Vacancy>> GetAll_Vacancies();
        Task<Vacancy?> Vacancy_Detail(string id);
    }
}
