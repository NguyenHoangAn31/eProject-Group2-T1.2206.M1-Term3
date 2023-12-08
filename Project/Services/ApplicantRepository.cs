using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Project.Services
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> CheckAccountExist(string email)
        {
            Applicant? applicant = await _db.Applicants!.SingleOrDefaultAsync(a => a.Email == email);
            if (applicant != null)
            {
                return true;
            }
            return false;
        }

        public string HashPassword(string plainPassword)
        {
            string storedSalt = "qwyriushvjkvnsHEWIFNSk"; 
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainPassword + storedSalt));
                string enteredPasswordHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return enteredPasswordHash;
            }

        }
        public Applicant? VerifyPassword(string? email , string? enterpassword)
        {
            Applicant? a = _db.Applicants!.SingleOrDefault(a=>a.Email == email && a.Password == HashPassword(enterpassword!));
            if (a != null)
            {
                return a;
            }
            return null;
        }
    }
}
