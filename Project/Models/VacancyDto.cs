using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class VacancyDto
    {
        public string? Vacancy_Id { get; set; }

        public string? Hr_Id { get; set; }
        [ValidateNever]
        public AppUser? AppUser { get; set; }
        public string? Department_Id { get; set; }
        [ValidateNever]
        public Department? Department { get; set; }
        public int Position_Id { get; set; }
        [ValidateNever]
        public Position? Position { get; set; }
        public int StatusVacancy_Id { get; set; }
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

    }
}
