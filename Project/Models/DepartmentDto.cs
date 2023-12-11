using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class DepartmentDto
    {
        [RegularExpression(@"^D[0-9]{4}$",
         ErrorMessage = "You must enter correct format D[0-9]")]
        public string? Department_Id { get; set; }
        public string? Name { get; set; }
    }
}
