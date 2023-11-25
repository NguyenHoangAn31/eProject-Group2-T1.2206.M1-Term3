using Project.Data;

namespace Project.Services.IRepository
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<int?> CheckLogin(string email , string password);
        Task<bool> CheckAccountExist(string email);
    }
}
