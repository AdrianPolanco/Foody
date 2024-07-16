using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DishesIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DinnerTable_IdTable",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "IdTable",
                table: "Order",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IdTable",
                table: "Order",
                newName: "IX_Order_TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DinnerTable_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "DinnerTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DinnerTable_TableId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Order",
                newName: "IdTable");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TableId",
                table: "Order",
                newName: "IX_Order_IdTable");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DinnerTable_IdTable",
                table: "Order",
                column: "IdTable",
                principalTable: "DinnerTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
