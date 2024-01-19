using CountrySearcher.Domain.Entities;
using CountrySearcher.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CountrySearcher.Infrastructure.Data
{
    public class CountrySearcherDbContext : DbContext
    {
        public CountrySearcherDbContext(DbContextOptions<CountrySearcherDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=:memory:");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryDetailsConfiguration());
        }

        public DbSet<Country> Countrys { get; set; }
        public DbSet<CountryDetail> CountryDetails { get; set; }
    }
}
