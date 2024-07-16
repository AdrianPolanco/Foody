
using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.Infrastructure.Persistence.Configurations
{
    public class DishOrderConfiguration : IEntityTypeConfiguration<DishOrder>
    {
        public void Configure(EntityTypeBuilder<DishOrder> builder)
        {
            builder.ToTable("DishesOrders");

         //   builder.HasKey(di => new { di.DishId, di.OrderId });

            builder.Property(di => di.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.HasOne(di => di.Dish)
                .WithMany(d => d.DishesOrders)
                .HasForeignKey(di => di.DishId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(di => di.Order)
                .WithMany(i => i.DishesOrders)
                .HasForeignKey(di => di.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(di => di.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(di => di.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasQueryFilter(di => !di.Deleted);
        }
    }
}
