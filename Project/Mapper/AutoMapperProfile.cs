using AutoMapper;
using Project.Data;
using Project.Models;

namespace Project.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Applicant,ApplicantDto>();
            CreateMap<ApplicantVacancy, ApplicantVacancyDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<InterviewVacancy, InterviewVacancyDto>();
            CreateMap<Job, JobDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<Vacancy, VacancyDto>();
            CreateMap<VacancyJob, VacancyJobDto>();


            CreateMap<ApplicantDto, Applicant>();
            CreateMap<ApplicantVacancyDto, ApplicantVacancy>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<InterviewVacancyDto, InterviewVacancy>();
            CreateMap<JobDto, Job>();
            CreateMap<PositionDto, Position>();
            CreateMap<VacancyDto, Vacancy>();
            CreateMap<VacancyJobDto, VacancyJob>();

        }
    }
}
