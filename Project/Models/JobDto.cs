using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class JobDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department_Id { get; set; }
        [ValidateNever]
        public Department? Department { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }


    }
}
