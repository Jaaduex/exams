using Microsoft.EntityFrameworkCore;

namespace MVCEntityFramework.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-44P5F9TO;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True");
            }
        }
    }
}
