using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Fullname { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
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
