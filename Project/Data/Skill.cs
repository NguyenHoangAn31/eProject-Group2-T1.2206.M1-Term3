using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data
{
    public class Skill : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        [ValidateNever]
        public Department? Department { get; set; }
        public virtual ICollection<VacancySkill>? VacanciesJobs { get; set; }

    }
}
