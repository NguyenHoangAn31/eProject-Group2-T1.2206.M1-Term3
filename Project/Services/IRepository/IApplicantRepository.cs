using Project.Data;

namespace Project.Services.IRepository
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<bool> CheckAccountExist(string email);

        string HashPassword(string plainPassword);
        Applicant? VerifyPassword(string? email , string? password);
    }
}
