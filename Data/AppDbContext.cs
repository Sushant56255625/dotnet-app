using Microsoft.EntityFrameworkCore;
using TestingApplication.Models;

namespace TestingApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> EmployeeDetails { get; set; }
    }
}