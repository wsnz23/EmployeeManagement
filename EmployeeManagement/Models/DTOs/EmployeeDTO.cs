using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
 
        public string Email { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
