﻿using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class VacancyRepository : Repository<Vacancy>, IVacancyRepository
    {
        ApplicationDbContext _db;

        public VacancyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Vacancy>> GetAll_Vacancies()
        {
            List<Vacancy> vacancies = await _db.Vacancies
              .Include(p => p.Position)
              .Include(one => one.VacanciesJobs!)
              .ThenInclude(job => job.Job)
              .ToListAsync();
            return vacancies;   
        }

        public async Task<Vacancy> Vacancy_Detail(string id)
        {
            Vacancy? vacancy = await _db.Vacancies
              .Include(p => p.Position)
              .Include(one => one.VacanciesJobs!)
              .ThenInclude(job => job.Job)
              .SingleOrDefaultAsync(v => v.Vacancy_Id == id);
            return vacancy;
        }
    }
}
