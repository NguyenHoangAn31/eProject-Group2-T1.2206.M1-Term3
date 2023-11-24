using System.ComponentModel.DataAnnotations;

namespace Project.Data
{
    public class StatusInterview : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
