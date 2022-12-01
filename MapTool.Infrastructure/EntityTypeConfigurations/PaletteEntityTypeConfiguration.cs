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
    public class PaletteEntityTypeConfiguration : IEntityTypeConfiguration<PaletteDto>
    {
        public void Configure(EntityTypeBuilder<PaletteDto> builder)
        {
            builder.ToTable("Palettes");
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.HasMany(x => x.Tiles).WithMany();
        }
    }
}
