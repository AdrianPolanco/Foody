
using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.Infrastructure.Persistence.Configurations
{
    internal class DishIngredientConfiguration : IEntityTypeConfiguration<DishIngredient>
    {
        public void Configure(EntityTypeBuilder<DishIngredient> builder)
        {
            builder.ToTable("DishesIngredients");

            builder.HasKey(di => new { di.DishId, di.IngredientId });

            // builder.HasIndex(di => di.Id).IsUnique();

            builder.Property(di => di.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.HasOne(di => di.Dish)
                .WithMany(d => d.DishesIngredients)
                .HasForeignKey(di => di.DishId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(di => di.Ingredient)
                .WithMany(i => i.DishesIngredients)
                .HasForeignKey(di => di.IngredientId)
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
