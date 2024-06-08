using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace codeFirstApproach.model
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public List<Employee>? Employees { get; set; } = new List<Employee>(); // Navigation property
    }
}
