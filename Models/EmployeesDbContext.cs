using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeesDbContext:DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options) { }
        public DbSet<Employees>Employees { get; set; }


    }
}
