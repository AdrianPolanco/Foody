
using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);

            builder.Ignore(o => o.Dishes);

            builder.Property(o => o.TableId)
                .IsRequired();

            builder.Property(o => o.Subtotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(o => o.State)
                .HasConversion<int>()
                .IsRequired();

            builder.HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(o => o.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasQueryFilter(o => !o.Deleted);
        }
    }
}
