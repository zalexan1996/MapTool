using MapTool.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Infrastructure.EntityTypeConfigurations
{
    public class TilePlacementEntityTypeConfiguration : IEntityTypeConfiguration<TilePlacementDto>
    {
        public void Configure(EntityTypeBuilder<TilePlacementDto> builder)
        {
            builder.ToTable("TilePlacements");
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);

            builder.Property(x => x.X).IsRequired();
            builder.Property(x => x.Y).IsRequired();
            builder.Property(x => x.Opacity).IsRequired().HasDefaultValue(1);
            builder.Property(x => x.VisibleInGame).IsRequired();
            builder.Property(x => x.Position).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.AdditionalDataJson).IsRequired().HasDefaultValue("").HasMaxLength(10000);

            builder.HasOne(x => x.Tile).WithMany().HasForeignKey(x => x.TileId);
        }
    }
}
