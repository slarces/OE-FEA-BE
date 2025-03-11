using Flag_Explorer_App.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Flag_Explorer_App.Infrastructure.Abstract
{
    public class AbstractDataContext : DbContext, IDataContext
    {
        // To detect redundant calls
        private bool _disposed = false;

        protected string ConnectionString { get; private set; }

        #region CTOR

        /// <summary>
        /// Creates an <see cref="AbstractDataContext"/> instance with <see cref="DbContextOptions{TContext}"/>.
        /// </summary>
        /// <param name="options"></param>
        protected AbstractDataContext(DbContextOptions options)
                   : base(options)
        { }

        /// <summary>
        /// Creates an <see cref="AbstractDataContext"/> instance with connection string.
        /// </summary>
        /// <param name="connString"></param>
        protected AbstractDataContext(string connString)
               : base()
        {
            ConnectionString = connString;
        }

        /// <summary>
        /// Destroy the instance
        /// </summary>
        ~AbstractDataContext() => Dispose(false);

        #endregion

        #region IDisposable Pattern Implementation

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // Dispose managed state (managed objects).
                //_safeHandle?.Dispose();
            }

            _disposed = true;
        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConnectionString, options =>
                {
                    optionsBuilder.EnableSensitiveDataLogging();
                });
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
