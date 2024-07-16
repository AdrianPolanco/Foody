

using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.Infrastructure.Persistence.Configurations
{
    internal class TableConfiguration : IEntityTypeConfiguration<DinnerTable>
    {
        public void Configure(EntityTypeBuilder<DinnerTable> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Capacity).IsRequired();

            builder.Property(t => t.State)
                .IsRequired()
                .HasConversion<int>();
        }
    }
}
