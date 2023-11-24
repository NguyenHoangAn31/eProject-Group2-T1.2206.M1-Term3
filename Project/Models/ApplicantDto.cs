namespace Project.Models
{
    public class ApplicantDto
    {
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
