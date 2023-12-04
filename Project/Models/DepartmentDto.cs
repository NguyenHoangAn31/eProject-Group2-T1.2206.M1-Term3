using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class DepartmentDto
    {
        [RegularExpression(@"^D[0-9]*$",
         ErrorMessage = "You must enter correct format D0000")]
        public string? Department_Id { get; set; }
        public string? Name { get; set; }
    }
}
