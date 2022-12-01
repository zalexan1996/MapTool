using MapTool.Core.Common.Exceptions;
using MapTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Services
{
    public interface IDatabaseManagementService
    {
        public static IMapToolDbContext? CurrentContext { get; protected set; }

        public Task<IMapToolDbContext> CreateDatabase(string databaseName, CancellationToken cancellationToken);
        public Task<bool> ImportDatabase(string databaseName, Stream fileStream, CancellationToken cancellationToken);
        public bool IsDatabaseLoaded()
        {
            return CurrentContext != null;
        }
    }

    public class DatabaseManagementService : IDatabaseManagementService
    {
        public DatabaseManagementService()
        {

        }

        public async Task<IMapToolDbContext> CreateDatabase(string databaseName, CancellationToken cancellationToken)
        {
            // Create the options builder.
            var builder = new DbContextOptionsBuilder<MapToolDbContext>()
                .UseSqlite($"Data Source={databaseName}.db")
                .EnableSensitiveDataLogging();

            // Create the db context
            var dbContext = new MapToolDbContext(builder.Options);

            // Create the database
            if (!await dbContext.Database.EnsureCreatedAsync(cancellationToken))
            {
                throw new DatabaseCreationFailureException("Failed to create the database");
            }

            IDatabaseManagementService.CurrentContext = dbContext;

            return dbContext;
        }

        public async Task<bool> ImportDatabase(string databaseName, Stream fileStream, CancellationToken cancellationToken)
        {
            // Read stream to the end, save it locally, then call CreateDatabase.

            return false;
        }
    }
}