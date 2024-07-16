using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NamesFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesIngredients_Order_OrderId",
                table: "DishesIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishesOrders_Ingredients_IngredientId",
                table: "DishesOrders");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "DishesOrders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DishesOrders_IngredientId",
                table: "DishesOrders",
                newName: "IX_DishesOrders_OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "DishesIngredients",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_DishesIngredients_OrderId",
                table: "DishesIngredients",
                newName: "IX_DishesIngredients_IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishesIngredients_Ingredients_IngredientId",
                table: "DishesIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishesOrders_Order_OrderId",
                table: "DishesOrders",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesIngredients_Ingredients_IngredientId",
                table: "DishesIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishesOrders_Order_OrderId",
                table: "DishesOrders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "DishesOrders",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_DishesOrders_OrderId",
                table: "DishesOrders",
                newName: "IX_DishesOrders_IngredientId");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "DishesIngredients",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DishesIngredients_IngredientId",
                table: "DishesIngredients",
                newName: "IX_DishesIngredients_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishesIngredients_Order_OrderId",
                table: "DishesIngredients",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishesOrders_Ingredients_IngredientId",
                table: "DishesOrders",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
