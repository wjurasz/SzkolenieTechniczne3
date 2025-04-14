using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.Common.Storage.Entities;
namespace SzkolenieTechniczne.Geo.Storage
{
    public class CompanyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CompanyDbContext(IConfiguration configuration)
            : base()
        {
            _configuration = configuration;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }
        public DbSet<SzkolenieTechniczne.Company.Storage.Entities.Company> Companies { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ContactTypeTranslation> ContactTypeTranslations { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobPositionTranslation> JobPositionTranslations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=company-dev;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Company"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}