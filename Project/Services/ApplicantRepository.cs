﻿using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int?> CheckLogin(string email, string password)
        {
            Applicant? applicant = await _db.Applicants.SingleOrDefaultAsync(a => a.Email == email && a.Password == password);
            if (applicant != null)
            {
                return applicant.Id;
            }
            return null;
        }
    }
}
