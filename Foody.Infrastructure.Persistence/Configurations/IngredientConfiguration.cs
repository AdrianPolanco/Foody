

using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.Infrastructure.Persistence.Configurations
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(i => i.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(i => !i.Deleted);

            builder.HasData(
              new Ingredient { Id = Guid.NewGuid(), Name = "Tomate" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Cebolla" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Ajo" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Perejil" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Cilantro" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Pepino" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Limon" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Sal" },
              new Ingredient { Id = Guid.NewGuid(), Name = "Pimienta" }                                                                                                                                                                          );
        }
    }
}
