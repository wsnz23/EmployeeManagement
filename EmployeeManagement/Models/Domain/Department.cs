using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Domain
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string DepName { get; set; }

    }
}
