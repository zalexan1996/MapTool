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
    public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            InfrastructureExtensionMethods.ConfigureKeyedEntity(builder);
            InfrastructureExtensionMethods.ConfigureInformationEntity(builder);
        }
    }
}
