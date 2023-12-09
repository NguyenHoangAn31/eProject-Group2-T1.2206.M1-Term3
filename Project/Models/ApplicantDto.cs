using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[\W_])[^\s*]{7,}$",
        ErrorMessage = "At least 7 characters, 1 number and 1 special character")]
        public string? Password { get; set; }
        [Required]
        public string? Fullname { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string? Image { get; set; }
        [Required]
        public string? Ward { get; set; }
        [Required]
        public string? District { get; set; }
        [Required]
        public string? Province { get; set; }
    }
}
