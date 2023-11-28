using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class VacancyJobDto
    {
        public int Id { get; set; }
        public string? Vacancy_Id { get; set; }
        [ValidateNever]
        public Vacancy? Vacancy { get; set; }
        public int? Job_Id { get; set; }
        [ValidateNever]
        public Job? Job { get; set; }
    }
}
