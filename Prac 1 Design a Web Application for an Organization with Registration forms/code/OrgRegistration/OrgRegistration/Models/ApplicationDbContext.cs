using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrgRegistration.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<RegistrationModel> Registrations { get; set; }
    }
}
