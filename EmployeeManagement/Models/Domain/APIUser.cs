﻿using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models.Domain
{
    public class APIUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
