using System.ComponentModel.DataAnnotations;

namespace Project.Data
{
    public class Applicant : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Image { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
    }
}
