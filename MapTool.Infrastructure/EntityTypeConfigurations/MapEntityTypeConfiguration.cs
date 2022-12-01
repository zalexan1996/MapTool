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
    public class MapEntityTypeConfiguration : IEntityTypeConfiguration<MapDto>
    {
        public void Configure(EntityTypeBuilder<MapDto> builder)
        {
            builder.ToTable("Maps");
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.HasMany(x => x.Tags).WithMany();
            builder.HasMany(x => x.TilePlacements).WithOne();
        }
    }
}
