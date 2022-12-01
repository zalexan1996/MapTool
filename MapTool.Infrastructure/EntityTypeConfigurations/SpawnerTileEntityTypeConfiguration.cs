﻿using MapTool.Domain.Types.UtilityTiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapTool.Infrastructure.EntityTypeConfigurations
{
    public class SpawnerTileEntityTypeConfiguration : IEntityTypeConfiguration<SpawnerTile>
    {
        public void Configure(EntityTypeBuilder<SpawnerTile> builder)
        {
            // InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            builder.ToTable(nameof(SpawnerTile));

            builder.Property(x => x.StartY).IsRequired();
            builder.Property(x => x.StartX).IsRequired();
            builder.Property(x => x.Width).IsRequired();
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.AssetReference).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Tilesheet).WithMany().HasForeignKey(x => x.ParentTilesheetId);
        }
    }
}
