using Employee_Api_23_12.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Api_23_12.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)       
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
