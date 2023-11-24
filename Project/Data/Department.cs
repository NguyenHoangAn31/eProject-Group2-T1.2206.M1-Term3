using System.ComponentModel.DataAnnotations;

namespace Project.Data
{
    public class Department : BaseEntity
    {
        [Key]
        public string? Department_Id { get; set; }
        public string? Name { get; set; }

    }
}
