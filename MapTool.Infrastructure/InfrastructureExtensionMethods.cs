using MapTool.Domain.Types.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Infrastructure
{
    internal static class InfrastructureExtensionMethods
    {
        internal static void ConfigureInformationEntity<T>(EntityTypeBuilder<T> builder) where T : class, IInformationEntity
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).IsRequired(true).HasDefaultValue("").HasMaxLength(2000);
        }
        internal static void ConfigureKeyedEntity<T>(EntityTypeBuilder<T> builder) where T : class, IKeyedEntity
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasAnnotation("IDENTITY", "1,1")
                .HasComment("Uniquely identifies this row.")
                .IsRequired();
        }
    }
}
