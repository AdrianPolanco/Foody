using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Foody.Infrastructure.Persistence.Configurations
{
    internal class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dishes");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(d => d.PeopleQuantity)
                .IsRequired();

            builder.Property(d => d.Category).HasConversion<int>().IsRequired();

            builder.Property(d => d.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();

            builder.HasQueryFilter(d => !d.Deleted);

            builder.HasMany(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .UsingEntity(j => j.ToTable("DishIngredients"));
        }
    }
}
