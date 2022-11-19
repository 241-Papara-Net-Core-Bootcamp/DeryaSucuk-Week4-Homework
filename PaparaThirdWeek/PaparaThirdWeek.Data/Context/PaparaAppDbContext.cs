using Microsoft.EntityFrameworkCore;
using PaparaThirdWeek.Data.Configurations;
using PaparaThirdWeek.Domain.Entities;

namespace PaparaThirdWeek.Data.Context
{
    public class PaparaAppDbContext : DbContext
    {
        public PaparaAppDbContext(DbContextOptions<PaparaAppDbContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            //DbContexdeki tüm table configurationları bulup regiter eder.
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaparaAppDbContext).Assembly);
        }
        public DbSet<Company> Companies { get; set; }


    }
}
