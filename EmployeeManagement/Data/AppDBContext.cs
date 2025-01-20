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
    }
}

//BRIDGE FROM OBJ TO DATABASE 