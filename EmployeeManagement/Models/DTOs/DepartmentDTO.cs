using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DTOs
{
    public class DepartmentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string DepName { get; set; }

    }
}
