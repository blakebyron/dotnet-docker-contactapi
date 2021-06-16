using System;
using System.IO;
using Contact.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contact.FunctionalTests
{
    public class DatabaseFixture:IDisposable
    {
        public readonly string ConnectionString;
        private readonly ContactDbContext context;
        private bool _disposed;

        public DatabaseFixture()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            ConnectionString = configuration["ConnectionString"];
            var builder = new DbContextOptionsBuilder<ContactDbContext>();
            string t = Directory.GetCurrentDirectory();

            builder.UseSqlServer(ConnectionString);
            context = new ContactDbContext(builder.Options);
            context.Database.Migrate();
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the database
                    this.context.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
