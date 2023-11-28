using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data
{
    public class ApplicantVacancy : BaseEntity
    {
        public int Id { get; set; }

        public string? Vacancy_Id { get; set; }
        [ForeignKey("Vacancy_Id")]
        [ValidateNever]
        public Vacancy? Vacancy { get; set; }
        public int? Applicant_Id { get; set; }
        [ForeignKey("Applicant_Id")]
        [ValidateNever]
        public Applicant? Applicant { get; set; }
        public string? Hr_Id { get; set; }
        [ForeignKey("Hr_Id")]
        [ValidateNever]
        public IdentityUser? IdentityUser { get; set; }
        public int StatusApplicant_Id { get; set; }
        [ForeignKey("StatusApplicant_Id")]
        [ValidateNever]
        public StatusApplicant? StatusApplicant { get; set; }
        public byte[]? Attachment { get;set; }
    }
}
