using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ComposedKeyRemoved2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesOrders",
                table: "DishesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients");

            migrationBuilder.DropIndex(
                name: "IX_DishesIngredients_DishId",
                table: "DishesIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesOrders",
                table: "DishesOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_DishesOrders_DishId",
                table: "DishesOrders",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesOrders",
                table: "DishesOrders");

            migrationBuilder.DropIndex(
                name: "IX_DishesOrders_DishId",
                table: "DishesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesOrders",
                table: "DishesOrders",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishesIngredients_DishId",
                table: "DishesIngredients",
                column: "DishId");
        }
    }
}
