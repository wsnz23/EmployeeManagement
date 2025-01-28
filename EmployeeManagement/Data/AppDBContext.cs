using EmployeeManagement.Extensions;
using EmployeeManagement.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class AppDBContext : IdentityDbContext<APIUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 

        }   
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedDepartment();
            modelBuilder.SeedEmployee();
        }

   }
}

//BRIDGE FROM OBJ TO DATABASE 