using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NuGet.Packaging.Signing;
using Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data
{
    public class Vacancy : BaseEntity
    {
        [Key]
        public string? Vacancy_Id { get; set; }

        public string? Hr_Id { get; set; }
        [ForeignKey("Hr_Id")]
        [ValidateNever]
        public AppUser? AppUser { get; set; }
        public string? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        [ValidateNever]
        public Department? Department { get; set; }
        public int Position_Id { get; set; }
        [ForeignKey("Position_Id")]
        [ValidateNever]
        public Position? Position { get; set; }
        public int StatusVacancy_Id { get; set; }
        [ForeignKey("StatusVacancy_Id")]
        [ValidateNever]
        public StatusVacancy? StatusVacancy { get; set; }
        public int ActualQuantity { get; set; }
        public int Quantity { get; set; }
        public int Salary { get; set; }
        public string? Place { get; set; }
        public string? Title { get; set; }
        public string? Requirement { get; set; }
        public string? Description { get; set; }
        public string? Benefits { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual ICollection<VacancySkill>? VacanciesSkills { get; set; }


    }
}
