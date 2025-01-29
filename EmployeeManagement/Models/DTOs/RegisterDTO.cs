﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10)]
        public string LastName { get; set; }
        [Required]

        [EmailAddress]
        public string Email { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]

        [Display(Name= "Confirm password")]

        [Compare("Password", ErrorMessage= "Password and confirmation password donot match.")]
        public string ConfirmPassword { get; set; }
        public ICollection<string> Roles{ get; set; }
    }
}
