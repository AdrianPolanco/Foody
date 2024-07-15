

using Foody.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.Infrastructure.Persistence.Configurations
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients");
            builder.Ignore(i => i.Dishes);
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(i => i.Name).IsUnique();
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(i => i.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(i => !i.Deleted);

            builder.HasData(
               new Ingredient { Id = Guid.Parse("00566d0c-ef75-4f2e-80e7-03cc96388cf4"), Name = "Cilantro", Deleted = false, CreatedAt = DateTime.Parse("2024-07-11 10:48:44.1269593") },
            new Ingredient { Id = Guid.Parse("886bba2e-9f4e-461d-bf7e-03d8caf8861d"), Name = "Limon", Deleted = false, CreatedAt = DateTime.Parse("2024-07-13 21:32:02.4225557") },
            new Ingredient { Id = Guid.Parse("e5993238-c45e-4734-1c26-08dca28e2f3e"), Name = "Garbanzos", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 12:17:54.1100151") },
            new Ingredient { Id = Guid.Parse("b08d05fb-c8fc-4b41-1c27-08dca28e2f3e"), Name = "Aguacate", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 12:18:52.6298430") },
            new Ingredient { Id = Guid.Parse("26896f67-9f97-4bfa-7af3-08dca2915059"), Name = "Nueces", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 12:39:46.3819054") },
            new Ingredient { Id = Guid.Parse("97bd18a8-3cf1-40e3-8426-08dca292b229"), Name = "Culcuma", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 12:50:11.7379175") },
            new Ingredient { Id = Guid.Parse("f37f07b2-823d-41fa-b110-08dca29a128f"), Name = "Habichuelas", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 13:42:59.9269183") },
            new Ingredient { Id = Guid.Parse("cdf7301a-3ae4-46a9-b29a-08dca29a3744"), Name = "Guandules", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 13:44:00.2163531") },
            new Ingredient { Id = Guid.Parse("ae2a2a39-68df-4e45-51f4-08dca29af6fc"), Name = "Arroz", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 13:49:22.4103141") },
            new Ingredient { Id = Guid.Parse("8254a0a5-efd7-4af7-51f5-08dca29af6fc"), Name = "Nachos", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 13:51:58.8252333") },
            new Ingredient { Id = Guid.Parse("84601fbf-d4b8-49d1-ee1a-08dca2a914ea"), Name = "Habichuelas blancas", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 15:30:26.3515601") },
            new Ingredient { Id = Guid.Parse("50549506-5354-494e-e461-08dca2afc987"), Name = "Frijoles", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:18:26.3504077") },
            new Ingredient { Id = Guid.Parse("c508e170-901c-42c4-fe94-08dca2b08c94"), Name = "Champiñon", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:23:53.5950378") },
            new Ingredient { Id = Guid.Parse("f5cbc849-480f-423e-10a1-08dca2b0af35"), Name = "Hummus", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:24:51.6886872") },
            new Ingredient { Id = Guid.Parse("74982b7e-4d9f-437e-81a2-08dca2b20eff"), Name = "Legumbres", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:34:41.8927646") },
            new Ingredient { Id = Guid.Parse("0d5e3f8c-3678-4bf8-7b74-08dca2b31642"), Name = "Zanahoria", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:42:03.5753897") },
            new Ingredient { Id = Guid.Parse("5e33cd41-61df-4c10-997f-08dca2b4b3ac"), Name = "Vainas", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:53:37.1670540") },
            new Ingredient { Id = Guid.Parse("6bd3fa32-c0d0-4e59-1b7e-08dca2b527ce"), Name = "Harina", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 16:56:52.0043200") },
            new Ingredient { Id = Guid.Parse("c1e7f1b9-c2d2-4cc0-bce8-08dca2b63451"), Name = "Espinaca", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 17:04:22.4912631") },
            new Ingredient { Id = Guid.Parse("82615949-0575-4305-4339-08dca2b6eba0"), Name = "Alcachofa", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 17:09:30.0317773") },
            new Ingredient { Id = Guid.Parse("eb619742-b130-455a-69c3-08dca2b712a7"), Name = "Ostras", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 17:10:35.5083334") },
            new Ingredient { Id = Guid.Parse("4c4bb54b-b566-4323-bb66-08dca2b7c3d6"), Name = "Manzana", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 17:15:32.7758302") },
            new Ingredient { Id = Guid.Parse("4997e6b2-fbd7-41c3-c193-08dca2b8acce"), Name = "Almejas", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 17:22:03.6331632") },
            new Ingredient { Id = Guid.Parse("d549d72a-af5b-4748-f312-08dca2b8d125"), Name = "Fresas", Deleted = false, CreatedAt = DateTime.Parse("2024-07-12 17:23:04.6028155") },
            new Ingredient { Id = Guid.Parse("b860fdaf-5a5c-4d8a-98f4-133f5b71a54a"), Name = "Azucar", Deleted = false, CreatedAt = DateTime.Parse("2024-07-14 01:19:13.9300000") },
            new Ingredient { Id = Guid.Parse("21dd65e8-5b65-4b52-b220-13e1ef028109"), Name = "Perejil", Deleted = false, CreatedAt = DateTime.Parse("2024-07-11 10:48:44.1269591") },
            new Ingredient { Id = Guid.Parse("aac2495d-b422-4dc2-ae14-386b8dcff963"), Name = "Cebolla", Deleted = false, CreatedAt = DateTime.Parse("2024-07-11 10:48:44.1269587") },
            new Ingredient { Id = Guid.Parse("e6c873c9-4118-4822-9603-3880f04664d3"), Name = "Pepino", Deleted = false, CreatedAt = DateTime.Parse("2024-07-13 21:32:02.4225555") },
            new Ingredient { Id = Guid.Parse("21c04671-e07d-4594-bae3-3d21d502a4ca"), Name = "Sal", Deleted = false, CreatedAt = DateTime.Parse("2024-07-13 21:32:02.4225558") },
            new Ingredient { Id = Guid.Parse("6d5c900e-e3c4-4f19-b502-46525f4d1010"), Name = "Cafe", Deleted = false, CreatedAt = DateTime.Parse("2024-07-14 01:20:13.4466667") },
            new Ingredient { Id = Guid.Parse("827812cc-6062-4236-9716-5205ff4b395a"), Name = "Pimienta", Deleted = false, CreatedAt = DateTime.Parse("2024-07-13 21:32:02.4225571") },
            new Ingredient { Id = Guid.Parse("787bb05e-ccb4-49a3-b8e3-5911d6c974bd"), Name = "Tomate", Deleted = false, CreatedAt = DateTime.Parse("2024-07-11 10:48:44.1269545") },
            new Ingredient { Id = Guid.Parse("e4e7cb92-46b7-42aa-accf-5f0a7bd79572"), Name = "Pimienta negra", Deleted = false, CreatedAt = DateTime.Parse("2024-07-11 10:48:44.1269615") },
            new Ingredient { Id = Guid.Parse("cb92444a-9c09-477c-9833-c15f1d9cba7b"), Name = "Ajo", Deleted = false, CreatedAt = DateTime.Parse("2024-07-11 10:48:44.1269589") },
            new Ingredient { Id = Guid.Parse("35367135-a35a-4b76-b9d6-ffc4260ad75b"), Name = "Agua", Deleted = false, CreatedAt = DateTime.Parse("2024-07-14 01:19:44.7766667") });
        }
    }
}
