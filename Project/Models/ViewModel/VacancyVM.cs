using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;

namespace Project.Models.ViewModel
{
    public class VacancyVM
    {
        public VacancyDto? vacancyDto { get; set; }
        public IEnumerable<SelectListItem>? PositionList { get; set; }
        public IEnumerable<SelectListItem>? JobList { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

    }
}
