using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Domain
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string Name { get; set; }
        [EmailAddress]
        //[RegularExpression] 
        public string Email { get; set; }

        [Display(Name="Dept")]
        public string Department { get; set; }
    }
}
