using MapTool.Domain.Types;
using MapTool.Domain.Types.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Infrastructure.EntityTypeConfigurations
{
    public class AnimatedTileEntityTypeConfiguration : IEntityTypeConfiguration<AnimatedTile>
    {
        public void Configure(EntityTypeBuilder<AnimatedTile> builder)
        {
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.Property(x => x.AnimationDelay).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.AnimationSpeed).IsRequired().HasDefaultValue(1000);
            builder.HasMany(x => x.Tiles).WithMany();
        }
    }
}
