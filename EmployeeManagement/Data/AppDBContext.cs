using EmployeeManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 

        }   
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {
                    Id = 2,
                    Name = "Hanaa", 
                    Email = "Hanaa@gmail.com",
                    Department = "HR",
                    Address = "Amman",
                    Salary = 600 }
                );
        }
    }
}

//BRIDGE FROM OBJ TO DATABASE 