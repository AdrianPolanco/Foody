using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDishesAndIngredients3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.RenameTable(
                name: "DishIngredients",
                newName: "DishesIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishesIngredients",
                newName: "IX_DishesIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishesIngredients_Dishes_DishId",
                table: "DishesIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishesIngredients_Ingredients_IngredientId",
                table: "DishesIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesIngredients_Dishes_DishId",
                table: "DishesIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishesIngredients_Ingredients_IngredientId",
                table: "DishesIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishesIngredients",
                table: "DishesIngredients");

            migrationBuilder.RenameTable(
                name: "DishesIngredients",
                newName: "DishIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_DishesIngredients_IngredientId",
                table: "DishIngredients",
                newName: "IX_DishIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
