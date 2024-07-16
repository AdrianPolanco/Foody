using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ComposedKeyRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishesIngredients_DishId",
                table: "DishesIngredients",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients");

            migrationBuilder.DropIndex(
                name: "IX_DishesIngredients_DishId",
                table: "DishesIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients",
                columns: new[] { "DishId", "IngredientId" });
        }
    }
}
