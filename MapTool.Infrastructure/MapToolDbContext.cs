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
        public DbSet<Tile> Tiles { get; set; }
        public DbSet<MapBridgeTile> MapBridgeTiles { get; set; }
        public DbSet<SpawnerTile> SpawnerTiles { get; set; }
        public DbSet<AnimatedTile> AnimatedTiles { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Palette> Palettes { get; set; }
        public DbSet<Prefab> Prefabs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TilePlacement> TilePlacements { get; set; }
        public DbSet<Tilesheet> Tilesheets { get; set; }

        public bool SaveChanges();
        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
    public class MapToolDbContext : DbContext, IMapToolDbContext
    {
        public MapToolDbContext(DbContextOptions<MapToolDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Tile> Tiles { get; set; }
        public virtual DbSet<MapBridgeTile> MapBridgeTiles { get; set; }
        public virtual DbSet<SpawnerTile> SpawnerTiles { get; set; }
        public virtual DbSet<AnimatedTile> AnimatedTiles { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<Palette> Palettes { get; set; }
        public virtual DbSet<Prefab> Prefabs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TilePlacement> TilePlacements { get; set; }
        public virtual DbSet<Tilesheet> Tilesheets { get; set; }

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
    }
}
