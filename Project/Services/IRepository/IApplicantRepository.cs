using Project.Data;

namespace Project.Services.IRepository
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<Applicant?> CheckLogin(string email , string password);
        Task<bool> CheckAccountExist(string email);
    }
}
