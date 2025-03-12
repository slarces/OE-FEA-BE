using Flag_Explorer_App.Domain.Entities.Country;
using Flag_Explorer_App.Dtos.Country;
using Flag_Explorer_App.Infrastructure.Abstract;
using Flag_Explorer_App.Infrastructure.Extensions;
using Flag_Explorer_App.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Flag_Explorer_App.Infrastructure
{
    public class FlagExplorerDbContext : AbstractDataContext
    {
        #region CTOR

        /// <summary>
        /// Creates an <see cref="FlagExplorerDbContext"/> instance with <see cref="DbContextOptions{FlagExplorerDbContext}"/>.
        /// </summary>
        /// <param name="options"></param>
        public FlagExplorerDbContext(DbContextOptions<FlagExplorerDbContext> options)
            : base(options)
        { }

        /// <summary>
        /// Creates an <see cref="FlagExplorerDbContext"/> instance with connection string.
        /// </summary>
        /// <param name="connString"></param>
        public FlagExplorerDbContext(string connString)
            : base(connString)
        { }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromSpecificAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedCountries();
        }

        public DbSet<CountryDetail> CountryDetail { get; set; }

        public DbSet<CountryLocation> CountryLocations { get; set; }

        public DbSet<CountryFlag> CountryFlag { get; set; }
    }
}
