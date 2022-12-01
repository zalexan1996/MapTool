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
    public class TilesheetEntityTypeConfiguration : IEntityTypeConfiguration<TilesheetDto>
    {
        public void Configure(EntityTypeBuilder<TilesheetDto> builder)
        {
            builder.ToTable("Tilesheets");
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.Property(x => x.AssetReference).IsRequired().HasMaxLength(500);
            builder.HasMany(x => x.Tiles).WithOne();
        }
    }
}
