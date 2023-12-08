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
            CreateMap<Skill, SkillDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<Vacancy, VacancyDto>();
            CreateMap<VacancySkill, VacancySkillDto>();


            CreateMap<ApplicantDto, Applicant>();
            CreateMap<ApplicantVacancyDto, ApplicantVacancy>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<InterviewVacancyDto, InterviewVacancy>();
            CreateMap<SkillDto, Skill>();
            CreateMap<PositionDto, Position>();
            CreateMap<VacancyDto, Vacancy>();
            CreateMap<VacancySkillDto, VacancySkill>();

        }
    }
}
