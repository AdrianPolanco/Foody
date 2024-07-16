using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NamesFixed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesOrders_Order_OrderId",
                table: "DishesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DinnerTable_TableId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TableId",
                table: "Orders",
                newName: "IX_Orders_TableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishesOrders_Orders_OrderId",
                table: "DishesOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DinnerTable_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "DinnerTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishesOrders_Orders_OrderId",
                table: "DishesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DinnerTable_TableId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TableId",
                table: "Order",
                newName: "IX_Order_TableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishesOrders_Order_OrderId",
                table: "DishesOrders",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DinnerTable_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "DinnerTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
