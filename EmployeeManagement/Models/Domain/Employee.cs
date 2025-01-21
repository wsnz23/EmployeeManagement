using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Domain
{
    public class Employee
    {
        [Required]
        //[Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [EmailAddress]
        //[RegularExpression] 
        public string Email { get; set; }

        [Display(Name="Dept")]
        public string Department { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
    }
}
