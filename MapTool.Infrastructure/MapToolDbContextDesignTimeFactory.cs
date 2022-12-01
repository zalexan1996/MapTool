using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Infrastructure
{
    public class MapToolDbContextDesignTimeFactory : IDesignTimeDbContextFactory<MapToolDbContext>
    {
        public MapToolDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MapToolDbContext>()
                .UseSqlite($"Data Source=test.db")
                // .UseSqlServer($"Server=localhost;Initial Catalog=MapTool;Integrated Security=true;TrustServerCertificate=true")
                .EnableSensitiveDataLogging();

            return new MapToolDbContext(builder.Options);
        }
    }
}
