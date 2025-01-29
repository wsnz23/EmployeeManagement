using EmployeeManagement.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                   new Employee
                   {
                       Id = 1,
                       Name = "Hanaa",
                       Email = "Hanaa@gmail.com",
                       //Department = "HR",
                       Address = "Amman",
                       Salary = 600,
                       DeptId=1
                   },
                   new Employee
                   {
                       Id = 2,
                       Name = "Hussein",
                       Email = "Hussein@gmail.com",
                       //Department = "IT",
                       Address = "Amman",
                       Salary = 650,
                       DeptId = 2

                   },
                     new Employee
                     {
                         Id = 3,
                         Name = "Salah",
                         Email = "Salahn@gmail.com",
                         //Department = "Finance",
                         Address = "Amman",
                         Salary = 900,
                         DeptId = 3
                     }
                   );
        }

        public static void SeedDepartment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                   new Department
                   {
                       Id = 1,
                       DepName = "HR",
                  
                   },
                   new Department
                   {
                       Id = 2,
                       DepName = "Finance",
        
                   },
                   new Department
                   {
                       Id = 3,
                       DepName = "IT",

                   }
                   );
        }

        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                   new IdentityRole
                   {
                       Name = "user",
                       NormalizedName = "USER",

                   },
                  new IdentityRole
                  {
                      Name = "administrator ",
                      NormalizedName = "ADMINISTRATOR",

                  }
                   );
        }

    }


}
