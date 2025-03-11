using Flag_Explorer_App.Infrastructure.Abstract;
using Flag_Explorer_App.Infrastructure.Extensions;
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
        }
    }
}
