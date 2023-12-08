using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data
{
    public class VacancySkill : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Vacancy_Id { get; set; }
        [ForeignKey("Vacancy_Id")]
        [ValidateNever]
        public Vacancy? Vacancy { get; set; }

        public int? Skill_Id { get; set; }
        [ForeignKey("Skill_Id")]
        [ValidateNever]
        public Skill? Skill { get; set; }
    }
}
