using EmployeeManagement.Extensions;
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
            modelBuilder.SeedDepartment();
            modelBuilder.SeedEmployee();
        }

        internal void SaveChangesAysnc()
        {
            throw new NotImplementedException();
        }
    }
}

//BRIDGE FROM OBJ TO DATABASE 