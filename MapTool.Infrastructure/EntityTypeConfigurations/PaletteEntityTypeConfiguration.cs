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
    public class PaletteEntityTypeConfiguration : IEntityTypeConfiguration<Palette>
    {
        public void Configure(EntityTypeBuilder<Palette> builder)
        {
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.HasMany(x => x.Tiles).WithMany();
        }
    }
}
