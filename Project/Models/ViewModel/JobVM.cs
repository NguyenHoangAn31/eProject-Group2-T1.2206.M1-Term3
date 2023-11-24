using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;

namespace Project.Models.ViewModel
{
    public class JobVM
    {
        public JobDto job { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }

    }
}
