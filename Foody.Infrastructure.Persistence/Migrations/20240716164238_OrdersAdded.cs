using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrdersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesIngredients_Ingredients_IngredientId",
                table: "DishesIngredients");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "DishesIngredients",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DishesIngredients_IngredientId",
                table: "DishesIngredients",
                newName: "IX_DishesIngredients_OrderId");

            migrationBuilder.CreateTable(
                name: "DishesOrders",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesOrders", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishesOrders_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishesOrders_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTable = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_DinnerTable_IdTable",
                        column: x => x.IdTable,
                        principalTable: "DinnerTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishesOrders_IngredientId",
                table: "DishesOrders",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdTable",
                table: "Order",
                column: "IdTable");

            migrationBuilder.AddForeignKey(
                name: "FK_DishesIngredients_Order_OrderId",
                table: "DishesIngredients",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesIngredients_Order_OrderId",
                table: "DishesIngredients");

            migrationBuilder.DropTable(
                name: "DishesOrders");

            migrationBuilder.DropTable(
                name: "Order");

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
        }
    }
}
