using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;

namespace Project.Models.ViewModel
{
    public class InterviewVM
    {
        public string? IdOfVacancy { get; set; }
        public int? IdOfApplicanVacancy { get; set; }
        public InterviewVacancyDto? InterviewVacancy { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? InterviewList { get; set; }
    }
}
