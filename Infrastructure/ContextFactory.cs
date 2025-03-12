using Flag_Explorer_App.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Flag_Explorer_App.Infrastructure
{
    public class ContextFactory : IDesignTimeDbContextFactory<FlagExplorerDbContext>
    {
        /// <summary>
        /// Creates <see cref="FlagExplorerDbContext"/>
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public FlagExplorerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlagExplorerDbContext>();

            optionsBuilder.UseSqlite(
                "Data Source=flagexplorer.db"
                ).EnableSensitiveDataLogging();
                
            return new FlagExplorerDbContext(optionsBuilder.Options);
        }
    }
}
