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
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<ProjectDto>
    {
        public void Configure(EntityTypeBuilder<ProjectDto> builder)
        {
            builder.ToTable("Projects");

            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);

            builder.Property(x => x.Author).IsRequired().HasMaxLength(256);
            builder.Property(x => x.VersionString).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.Maps).WithOne();
        }
    }
}
