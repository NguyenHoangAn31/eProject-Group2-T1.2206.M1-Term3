using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data
{
    public class AppUser : IdentityUser
    {
        public string? Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        [ValidateNever]
        public Department? Department { get; set; }
        public string? Employeecode { get; set; }
        public string? Fullname { get; set; }
        public string? Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }

    }
}   
