using Consent_Form.Model;
using Microsoft.EntityFrameworkCore;

namespace Consent_Form.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<models> ModelTable { get; set; }
        public DbSet<Patient> PatientTable { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
