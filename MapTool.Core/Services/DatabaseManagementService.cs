using MapTool.Core.Common.Exceptions;
using MapTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MapTool.Core.Services
{
    public interface IDatabaseManagementService
    {
        public static IMapToolDbContext? CurrentContext { get; protected set; }

        public Task<IMapToolDbContext> CreateDatabase(string databaseName, CancellationToken cancellationToken);
        public Task<IMapToolDbContext> LoadDatabase(string databaseName, CancellationToken cancellationToken);
        public Task<bool> ImportDatabase(string databaseName, Stream fileStream, CancellationToken cancellationToken);
        public bool IsDatabaseLoaded()
        {
            return CurrentContext != null;
        }
        public (string name, string path)[] ListDatabases();
        public bool DoesDatabaseExist(string databaseName);
    }                  

    public class DatabaseManagementService : IDatabaseManagementService
    {
        private readonly string databaseFolderName = "Databases";

        public DatabaseManagementService()
        {

        }

        protected void DisposeOldContext()
        {
            if (IDatabaseManagementService.CurrentContext != null)
            {
                IDatabaseManagementService.CurrentContext.DisposeAsync();
            }
        }

        public async Task<IMapToolDbContext> CreateDatabase(string databaseName, CancellationToken cancellationToken)
        {
            string dbPath = $"./{databaseFolderName}/{databaseName}";

            // Don't overwrite an existing database
            if (File.Exists($"{dbPath}.db"))
            {
                throw new DatabaseCreationFailureException($"A database with the name {databaseName} already exists.", DatabaseCreationFailureException.FailureReason.DatabaseAlreadyExists);
            }

            // Create the db context
            var dbContext = new MapToolDbContext(dbPath);

            // Create the database
            if (!await dbContext.Database.EnsureCreatedAsync(cancellationToken))
            {
                throw new DatabaseCreationFailureException("Failed to create the database");
            }

            DisposeOldContext();
            
            IDatabaseManagementService.CurrentContext = dbContext;

            return dbContext;
        }

        public async Task<bool> ImportDatabase(string databaseName, Stream fileStream, CancellationToken cancellationToken)
        {
            string dbPath = $"{databaseFolderName}/{databaseName}";

            // Don't overwrite an existing database
            if (File.Exists(dbPath))
            {
                throw new DatabaseCreationFailureException($"A database with the name {databaseName} already exists.", DatabaseCreationFailureException.FailureReason.DatabaseAlreadyExists);
            }

            // Copy the input file stream to the database folder.
            using (Stream outputStream = File.OpenWrite($"{databaseFolderName}/{databaseName}.db"))
            {
                await fileStream.CopyToAsync(outputStream);
            }

            return false;
        }

        public async Task<IMapToolDbContext> LoadDatabase(string databaseName, CancellationToken cancellationToken)
        {
            string dbPath = $"{databaseFolderName}/{databaseName}";
            if (!File.Exists(dbPath))
            {
                throw new DatabaseNonExistException($"Could not find database '{databaseName}.db' in path ./{databaseFolderName}");
            }

            var dbContext = new MapToolDbContext(dbPath);

            DisposeOldContext();

            IDatabaseManagementService.CurrentContext = dbContext;

            return dbContext;
        }

        public bool DoesDatabaseExist(string databaseName)
        {
            return Directory.GetFiles($"./{databaseFolderName}", $"{databaseName}.db").Any();
        }

        (string name, string path)[] IDatabaseManagementService.ListDatabases()
        {
            var files = Directory.GetFiles($"./{databaseFolderName}", "*.db");

            return files.Select(x => (Regex.Match(x, $"(?<=({databaseFolderName}(\\\\|/))).*(?=(\\.db))").Groups[0].Value, x)).ToArray();
        }
    }
}