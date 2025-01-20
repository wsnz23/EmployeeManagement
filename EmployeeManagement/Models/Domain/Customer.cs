using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.EmployeeManagement.Models.Domain
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
