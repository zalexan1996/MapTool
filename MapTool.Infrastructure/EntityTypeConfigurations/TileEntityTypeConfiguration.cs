using MapTool.Domain.Types;
using MapTool.Domain.Types.UtilityTiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Infrastructure.EntityTypeConfigurations
{
    public class TileEntityTypeConfiguration : IEntityTypeConfiguration<TileDto>
    {
        public void Configure(EntityTypeBuilder<TileDto> builder)
        {
            builder.ToTable("Tiles");
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            builder.ToTable(nameof(TileDto));

            builder.Property(x => x.StartX).IsRequired();
            builder.Property(x => x.StartY).IsRequired();

            builder.Property(x => x.Width).IsRequired();
            builder.Property(x => x.Width).IsRequired();

            builder.HasOne(x => x.Tilesheet).WithMany().HasForeignKey(x => x.ParentTilesheetId);
        }
    }
}
