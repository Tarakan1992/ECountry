using Microsoft.EntityFrameworkCore;

namespace ECountry.Infrastructure
{
    public class ECountryDbContext : DbContext
    {
        public ECountryDbContext(DbContextOptions<ECountryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
