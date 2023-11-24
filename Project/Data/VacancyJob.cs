using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data
{
    public class VacancyJob : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Vacancy_Id { get; set; }
        [ForeignKey("Vacancy_Id")]
        [ValidateNever]
        public Vacancy? Vacancy { get; set; }

        public int? Job_Id { get; set; }
        [ForeignKey("Job_Id")]
        [ValidateNever]
        public Job? Job { get; set; }
    }
}
