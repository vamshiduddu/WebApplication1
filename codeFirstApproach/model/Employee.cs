using codeFirstApproach.model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeFirstApproach.model
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(100)]
        public string Department { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager? Manager { get; set; } // Navigation property
    }
}


/*dotnet ef migrations add InitialCreate --project F:/NetCore/projects/WebApplication1/codeFirstApproach/codeFirstApproach.csproj
   dotnet ef database update  --project F:/NetCore/projects/WebApplication1/codeFirstApproach/codeFirstApproach.csproj
*/


