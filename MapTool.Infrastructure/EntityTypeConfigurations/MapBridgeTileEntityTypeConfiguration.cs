﻿using MapTool.Domain.Types.Interfaces;
using MapTool.Domain.Types.UtilityTiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapTool.Infrastructure.EntityTypeConfigurations
{
    public class MapBridgeTileEntityTypeConfiguration : IEntityTypeConfiguration<MapBridgeTile>
    {
        public void Configure(EntityTypeBuilder<MapBridgeTile> builder)
        {
            // InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            builder.ToTable(nameof(MapBridgeTile));

            builder.Property(x => x.StartY).IsRequired();
            builder.Property(x => x.StartX).IsRequired();
            builder.Property(x => x.Width).IsRequired();
            builder.Property(x => x.Height).IsRequired();

            builder.HasOne(x => x.Tilesheet).WithMany().HasForeignKey(x => x.ParentTilesheetId);

            builder.HasOne(x => x.DestinationMap).WithMany().HasForeignKey(x => x.DestinationMapId);
        }
    }
}
