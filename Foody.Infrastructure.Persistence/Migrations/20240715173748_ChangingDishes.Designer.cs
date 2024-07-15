﻿// <auto-generated />
using System;
using Foody.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240715173748_ChangingDishes")]
    partial class ChangingDishes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Foody.Core.Domain.Entities.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PeopleQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Dishes", (string)null);
                });

            modelBuilder.Entity("Foody.Core.Domain.Entities.DishIngredient", b =>
                {
                    b.Property<Guid>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients", (string)null);
                });

            modelBuilder.Entity("Foody.Core.Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredients", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00566d0c-ef75-4f2e-80e7-03cc96388cf4"),
                            CreatedAt = new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9593),
                            Deleted = false,
                            Name = "Cilantro"
                        },
                        new
                        {
                            Id = new Guid("886bba2e-9f4e-461d-bf7e-03d8caf8861d"),
                            CreatedAt = new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5557),
                            Deleted = false,
                            Name = "Limon"
                        },
                        new
                        {
                            Id = new Guid("e5993238-c45e-4734-1c26-08dca28e2f3e"),
                            CreatedAt = new DateTime(2024, 7, 12, 12, 17, 54, 110, DateTimeKind.Unspecified).AddTicks(151),
                            Deleted = false,
                            Name = "Garbanzos"
                        },
                        new
                        {
                            Id = new Guid("b08d05fb-c8fc-4b41-1c27-08dca28e2f3e"),
                            CreatedAt = new DateTime(2024, 7, 12, 12, 18, 52, 629, DateTimeKind.Unspecified).AddTicks(8430),
                            Deleted = false,
                            Name = "Aguacate"
                        },
                        new
                        {
                            Id = new Guid("26896f67-9f97-4bfa-7af3-08dca2915059"),
                            CreatedAt = new DateTime(2024, 7, 12, 12, 39, 46, 381, DateTimeKind.Unspecified).AddTicks(9054),
                            Deleted = false,
                            Name = "Nueces"
                        },
                        new
                        {
                            Id = new Guid("97bd18a8-3cf1-40e3-8426-08dca292b229"),
                            CreatedAt = new DateTime(2024, 7, 12, 12, 50, 11, 737, DateTimeKind.Unspecified).AddTicks(9175),
                            Deleted = false,
                            Name = "Culcuma"
                        },
                        new
                        {
                            Id = new Guid("f37f07b2-823d-41fa-b110-08dca29a128f"),
                            CreatedAt = new DateTime(2024, 7, 12, 13, 42, 59, 926, DateTimeKind.Unspecified).AddTicks(9183),
                            Deleted = false,
                            Name = "Habichuelas"
                        },
                        new
                        {
                            Id = new Guid("cdf7301a-3ae4-46a9-b29a-08dca29a3744"),
                            CreatedAt = new DateTime(2024, 7, 12, 13, 44, 0, 216, DateTimeKind.Unspecified).AddTicks(3531),
                            Deleted = false,
                            Name = "Guandules"
                        },
                        new
                        {
                            Id = new Guid("ae2a2a39-68df-4e45-51f4-08dca29af6fc"),
                            CreatedAt = new DateTime(2024, 7, 12, 13, 49, 22, 410, DateTimeKind.Unspecified).AddTicks(3141),
                            Deleted = false,
                            Name = "Arroz"
                        },
                        new
                        {
                            Id = new Guid("8254a0a5-efd7-4af7-51f5-08dca29af6fc"),
                            CreatedAt = new DateTime(2024, 7, 12, 13, 51, 58, 825, DateTimeKind.Unspecified).AddTicks(2333),
                            Deleted = false,
                            Name = "Nachos"
                        },
                        new
                        {
                            Id = new Guid("84601fbf-d4b8-49d1-ee1a-08dca2a914ea"),
                            CreatedAt = new DateTime(2024, 7, 12, 15, 30, 26, 351, DateTimeKind.Unspecified).AddTicks(5601),
                            Deleted = false,
                            Name = "Habichuelas blancas"
                        },
                        new
                        {
                            Id = new Guid("50549506-5354-494e-e461-08dca2afc987"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 18, 26, 350, DateTimeKind.Unspecified).AddTicks(4077),
                            Deleted = false,
                            Name = "Frijoles"
                        },
                        new
                        {
                            Id = new Guid("c508e170-901c-42c4-fe94-08dca2b08c94"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 23, 53, 595, DateTimeKind.Unspecified).AddTicks(378),
                            Deleted = false,
                            Name = "Champiñon"
                        },
                        new
                        {
                            Id = new Guid("f5cbc849-480f-423e-10a1-08dca2b0af35"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 24, 51, 688, DateTimeKind.Unspecified).AddTicks(6872),
                            Deleted = false,
                            Name = "Hummus"
                        },
                        new
                        {
                            Id = new Guid("74982b7e-4d9f-437e-81a2-08dca2b20eff"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 34, 41, 892, DateTimeKind.Unspecified).AddTicks(7646),
                            Deleted = false,
                            Name = "Legumbres"
                        },
                        new
                        {
                            Id = new Guid("0d5e3f8c-3678-4bf8-7b74-08dca2b31642"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 42, 3, 575, DateTimeKind.Unspecified).AddTicks(3897),
                            Deleted = false,
                            Name = "Zanahoria"
                        },
                        new
                        {
                            Id = new Guid("5e33cd41-61df-4c10-997f-08dca2b4b3ac"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 53, 37, 167, DateTimeKind.Unspecified).AddTicks(540),
                            Deleted = false,
                            Name = "Vainas"
                        },
                        new
                        {
                            Id = new Guid("6bd3fa32-c0d0-4e59-1b7e-08dca2b527ce"),
                            CreatedAt = new DateTime(2024, 7, 12, 16, 56, 52, 4, DateTimeKind.Unspecified).AddTicks(3200),
                            Deleted = false,
                            Name = "Harina"
                        },
                        new
                        {
                            Id = new Guid("c1e7f1b9-c2d2-4cc0-bce8-08dca2b63451"),
                            CreatedAt = new DateTime(2024, 7, 12, 17, 4, 22, 491, DateTimeKind.Unspecified).AddTicks(2631),
                            Deleted = false,
                            Name = "Espinaca"
                        },
                        new
                        {
                            Id = new Guid("82615949-0575-4305-4339-08dca2b6eba0"),
                            CreatedAt = new DateTime(2024, 7, 12, 17, 9, 30, 31, DateTimeKind.Unspecified).AddTicks(7773),
                            Deleted = false,
                            Name = "Alcachofa"
                        },
                        new
                        {
                            Id = new Guid("eb619742-b130-455a-69c3-08dca2b712a7"),
                            CreatedAt = new DateTime(2024, 7, 12, 17, 10, 35, 508, DateTimeKind.Unspecified).AddTicks(3334),
                            Deleted = false,
                            Name = "Ostras"
                        },
                        new
                        {
                            Id = new Guid("4c4bb54b-b566-4323-bb66-08dca2b7c3d6"),
                            CreatedAt = new DateTime(2024, 7, 12, 17, 15, 32, 775, DateTimeKind.Unspecified).AddTicks(8302),
                            Deleted = false,
                            Name = "Manzana"
                        },
                        new
                        {
                            Id = new Guid("4997e6b2-fbd7-41c3-c193-08dca2b8acce"),
                            CreatedAt = new DateTime(2024, 7, 12, 17, 22, 3, 633, DateTimeKind.Unspecified).AddTicks(1632),
                            Deleted = false,
                            Name = "Almejas"
                        },
                        new
                        {
                            Id = new Guid("d549d72a-af5b-4748-f312-08dca2b8d125"),
                            CreatedAt = new DateTime(2024, 7, 12, 17, 23, 4, 602, DateTimeKind.Unspecified).AddTicks(8155),
                            Deleted = false,
                            Name = "Fresas"
                        },
                        new
                        {
                            Id = new Guid("b860fdaf-5a5c-4d8a-98f4-133f5b71a54a"),
                            CreatedAt = new DateTime(2024, 7, 14, 1, 19, 13, 930, DateTimeKind.Unspecified),
                            Deleted = false,
                            Name = "Azucar"
                        },
                        new
                        {
                            Id = new Guid("21dd65e8-5b65-4b52-b220-13e1ef028109"),
                            CreatedAt = new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9591),
                            Deleted = false,
                            Name = "Perejil"
                        },
                        new
                        {
                            Id = new Guid("aac2495d-b422-4dc2-ae14-386b8dcff963"),
                            CreatedAt = new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9587),
                            Deleted = false,
                            Name = "Cebolla"
                        },
                        new
                        {
                            Id = new Guid("e6c873c9-4118-4822-9603-3880f04664d3"),
                            CreatedAt = new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5555),
                            Deleted = false,
                            Name = "Pepino"
                        },
                        new
                        {
                            Id = new Guid("21c04671-e07d-4594-bae3-3d21d502a4ca"),
                            CreatedAt = new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5558),
                            Deleted = false,
                            Name = "Sal"
                        },
                        new
                        {
                            Id = new Guid("6d5c900e-e3c4-4f19-b502-46525f4d1010"),
                            CreatedAt = new DateTime(2024, 7, 14, 1, 20, 13, 446, DateTimeKind.Unspecified).AddTicks(6667),
                            Deleted = false,
                            Name = "Cafe"
                        },
                        new
                        {
                            Id = new Guid("827812cc-6062-4236-9716-5205ff4b395a"),
                            CreatedAt = new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5571),
                            Deleted = false,
                            Name = "Pimienta"
                        },
                        new
                        {
                            Id = new Guid("787bb05e-ccb4-49a3-b8e3-5911d6c974bd"),
                            CreatedAt = new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9545),
                            Deleted = false,
                            Name = "Tomate"
                        },
                        new
                        {
                            Id = new Guid("e4e7cb92-46b7-42aa-accf-5f0a7bd79572"),
                            CreatedAt = new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9615),
                            Deleted = false,
                            Name = "Pimienta negra"
                        },
                        new
                        {
                            Id = new Guid("cb92444a-9c09-477c-9833-c15f1d9cba7b"),
                            CreatedAt = new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9589),
                            Deleted = false,
                            Name = "Ajo"
                        },
                        new
                        {
                            Id = new Guid("35367135-a35a-4b76-b9d6-ffc4260ad75b"),
                            CreatedAt = new DateTime(2024, 7, 14, 1, 19, 44, 776, DateTimeKind.Unspecified).AddTicks(6667),
                            Deleted = false,
                            Name = "Agua"
                        });
                });

            modelBuilder.Entity("Foody.Infrastructure.Persistence.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Foody.Core.Domain.Entities.DishIngredient", b =>
                {
                    b.HasOne("Foody.Core.Domain.Entities.Dish", "Dish")
                        .WithMany("Ingredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Foody.Core.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("Dishes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Foody.Infrastructure.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Foody.Infrastructure.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foody.Infrastructure.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Foody.Infrastructure.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foody.Core.Domain.Entities.Dish", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Foody.Core.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
