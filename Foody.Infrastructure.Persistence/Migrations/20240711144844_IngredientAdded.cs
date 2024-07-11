using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IngredientAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("00566d0c-ef75-4f2e-80e7-03cc96388cf4"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9593), "Cilantro" },
                    { new Guid("21dd65e8-5b65-4b52-b220-13e1ef028109"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9591), "Perejil" },
                    { new Guid("5d28d108-9794-4e3f-82f7-c90fdab4437c"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9594), "Pepino" },
                    { new Guid("6569a9f6-eae3-478f-bf5d-d5f957bc9daf"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9613), "Sal" },
                    { new Guid("787bb05e-ccb4-49a3-b8e3-5911d6c974bd"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9545), "Tomate" },
                    { new Guid("aac2495d-b422-4dc2-ae14-386b8dcff963"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9587), "Cebolla" },
                    { new Guid("cb92444a-9c09-477c-9833-c15f1d9cba7b"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9589), "Ajo" },
                    { new Guid("e4e7cb92-46b7-42aa-accf-5f0a7bd79572"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9615), "Pimienta" },
                    { new Guid("fa545a0b-2158-4b2d-840c-32c99face061"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Local).AddTicks(9596), "Limon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
