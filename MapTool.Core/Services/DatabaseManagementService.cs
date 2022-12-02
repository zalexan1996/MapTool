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
        public Task<bool> DeleteDatabase(string databasePath);

        public string GetInvalidCharacters()
        {
            return ",./?;\"':[]{}!@#$%^&*()-_=+\\| ";
        }
        public bool IsNameAcceptable(string name)
        {
            return !(string.IsNullOrWhiteSpace(name)
                || GetInvalidCharacters().Split("").Any(c => name.Contains(c))
                || DoesDatabaseExist(name));
        }
        public delegate void OnDatabaseChanged(string newName, string newPath);
        event OnDatabaseChanged DatabaseChanged;
    }                  

    public class DatabaseManagementService : IDatabaseManagementService
    {
        private readonly string databaseFolderName = "Databases";

        public event IDatabaseManagementService.OnDatabaseChanged DatabaseChanged;

        public DatabaseManagementService()
        {

        }

        private string GetDatabasePathFromName(string dbName)
        {
            return $"./{databaseFolderName}\\{dbName}.db";
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
            string dbPath = GetDatabasePathFromName(databaseName);

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
            DatabaseChanged?.Invoke(databaseName, dbPath);

            return dbContext;
        }

        public async Task<bool> ImportDatabase(string databaseName, Stream fileStream, CancellationToken cancellationToken)
        {
            string dbPath = GetDatabasePathFromName(databaseName);

            // Don't overwrite an existing database
            if (File.Exists(dbPath))
            {
                throw new DatabaseCreationFailureException($"A database with the name {databaseName} already exists.", DatabaseCreationFailureException.FailureReason.DatabaseAlreadyExists);
            }

            // Copy the input file stream to the database folder.
            using (Stream outputStream = File.OpenWrite(dbPath))
            {
                await fileStream.CopyToAsync(outputStream);
            }

            return false;
        }

        public async Task<IMapToolDbContext> LoadDatabase(string databaseName, CancellationToken cancellationToken)
        {
            string dbPath = GetDatabasePathFromName(databaseName);
            if (!File.Exists(dbPath))
            {
                throw new DatabaseNonExistException($"Could not find database '{databaseName}.db' in path ./{databaseFolderName}");
            }

            var dbContext = new MapToolDbContext(dbPath);

            DisposeOldContext();

            IDatabaseManagementService.CurrentContext = dbContext;
            DatabaseChanged?.Invoke(databaseName, dbPath);

            return dbContext;
        }

        public bool DoesDatabaseExist(string databaseName)
        {
            return File.Exists(GetDatabasePathFromName(databaseName));
        }

        (string name, string path)[] IDatabaseManagementService.ListDatabases()
        {
            var files = Directory.GetFiles($"./{databaseFolderName}", "*.db");

            return files.Select(x => (Regex.Match(x, $"(?<=({databaseFolderName}(\\\\|/))).*(?=(\\.db))").Groups[0].Value, x)).ToArray();
        }

        public async Task<bool> DeleteDatabase(string databasePath)
        {
            if (!File.Exists(databasePath))
            {
                throw new DatabaseNonExistException("Could not delete the database because it does not exist.");
            }

            if (IDatabaseManagementService.CurrentContext?.DatabasePath == databasePath)
            {
                return false;
            }

            try
            {
                File.Delete(databasePath);
                File.Delete($"{databasePath}-wal");
                File.Delete($"{databasePath}-shm");
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}