using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;

namespace Project.Models.ViewModel
{
    public class SkillVM
    {
        public SkillDto? skill { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? DepartmentList { get; set; }

    }
}
