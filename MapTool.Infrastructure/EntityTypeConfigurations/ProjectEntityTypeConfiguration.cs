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
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.Property(x => x.Author).IsRequired().HasMaxLength(256);
            builder.Property(x => x.VersionString).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.Prefabs).WithOne();
            builder.HasMany(x => x.Maps).WithOne();
            builder.HasMany(x => x.Tilesheets).WithOne();
            builder.HasMany(x => x.Palettes).WithOne();
        }
    }
}
