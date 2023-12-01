using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class ApplicantVacancyDto
    {
        public int Id { get; set; }

        public string? Vacancy_Id { get; set; }
        [ValidateNever]
        public Vacancy? Vacancy { get; set; }
        public int? Applicant_Id { get; set; }
        [ValidateNever]
        public Applicant? Applicant { get; set; }
        public string? Hr_Id { get; set; }
        [ValidateNever]
        public AppUser? AppUser { get; set; }
        public int StatusApplicant_Id { get; set; }
        [ValidateNever]
        public StatusApplicant? StatusApplicant { get; set; }
        public byte[]? Attachment { get; set; }

    }
}
