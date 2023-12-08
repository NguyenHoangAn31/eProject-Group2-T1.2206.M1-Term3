using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class VacancySkillDto
    {
        public int Id { get; set; }
        public string? Vacancy_Id { get; set; }
        [ValidateNever]
        public Vacancy? Vacancy { get; set; }
        public int? Skill_Id { get; set; }
        [ValidateNever]
        public Skill? Skill { get; set; }
    }
}
