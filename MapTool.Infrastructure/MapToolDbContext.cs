using MapTool.Domain.Types;
using MapTool.Domain.Types.UtilityTiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Infrastructure
{
    public interface IMapToolDbContext
    {
        public DbSet<TileDto> Tiles { get; set; }
        public DbSet<MapBridgeTileDto> MapBridgeTiles { get; set; }
        public DbSet<SpawnerTileDto> SpawnerTiles { get; set; }
        public DbSet<AnimatedTileDto> AnimatedTiles { get; set; }
        public DbSet<MapDto> Maps { get; set; }
        public DbSet<PaletteDto> Palettes { get; set; }
        public DbSet<PrefabDto> Prefabs { get; set; }
        public DbSet<ProjectDto> Projects { get; set; }
        public DbSet<TagDto> Tags { get; set; }
        public DbSet<TilePlacementDto> TilePlacements { get; set; }
        public DbSet<TilesheetDto> Tilesheets { get; set; }

        public bool SaveChanges();
        public ValueTask DisposeAsync();
        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
        public string DatabasePath { get; }
    }

    public class MapToolDbContext : DbContext, IMapToolDbContext
    {
        private readonly string _databasePath;
        public MapToolDbContext(string databasePath) : base(GetContextOptions(databasePath))
        {
            _databasePath = databasePath;
        }

        public static DbContextOptions<MapToolDbContext> GetContextOptions(string databasePath)
        {
            return new DbContextOptionsBuilder<MapToolDbContext>()
                .UseSqlite($"Data Source={databasePath}")
                .EnableSensitiveDataLogging()
                .Options;
        }
        public MapToolDbContext(DbContextOptions<MapToolDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<TileDto> Tiles { get; set; }
        public virtual DbSet<MapBridgeTileDto> MapBridgeTiles { get; set; }
        public virtual DbSet<SpawnerTileDto> SpawnerTiles { get; set; }
        public virtual DbSet<AnimatedTileDto> AnimatedTiles { get; set; }
        public virtual DbSet<MapDto> Maps { get; set; }
        public virtual DbSet<PaletteDto> Palettes { get; set; }
        public virtual DbSet<PrefabDto> Prefabs { get; set; }
        public virtual DbSet<ProjectDto> Projects { get; set; }
        public virtual DbSet<TagDto> Tags { get; set; }
        public virtual DbSet<TilePlacementDto> TilePlacements { get; set; }
        public virtual DbSet<TilesheetDto> Tilesheets { get; set; }

        public string DatabasePath => _databasePath;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        bool IMapToolDbContext.SaveChanges()
        {
            return base.SaveChanges() > 0;
        }

        async Task<bool> IMapToolDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return (await base.SaveChangesAsync(cancellationToken)) > 0;
        }

        async ValueTask IMapToolDbContext.DisposeAsync()
        {
            await base.Database.CloseConnectionAsync();
            await base.DisposeAsync();

        }
    }
}
