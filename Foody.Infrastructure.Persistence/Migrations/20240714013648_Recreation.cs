using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foody.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Recreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PeopleQuantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("00566d0c-ef75-4f2e-80e7-03cc96388cf4"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9593), "Cilantro" },
                    { new Guid("0d5e3f8c-3678-4bf8-7b74-08dca2b31642"), new DateTime(2024, 7, 12, 16, 42, 3, 575, DateTimeKind.Unspecified).AddTicks(3897), "Zanahoria" },
                    { new Guid("21c04671-e07d-4594-bae3-3d21d502a4ca"), new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5558), "Sal" },
                    { new Guid("21dd65e8-5b65-4b52-b220-13e1ef028109"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9591), "Perejil" },
                    { new Guid("26896f67-9f97-4bfa-7af3-08dca2915059"), new DateTime(2024, 7, 12, 12, 39, 46, 381, DateTimeKind.Unspecified).AddTicks(9054), "Nueces" },
                    { new Guid("35367135-a35a-4b76-b9d6-ffc4260ad75b"), new DateTime(2024, 7, 14, 1, 19, 44, 776, DateTimeKind.Unspecified).AddTicks(6667), "Agua" },
                    { new Guid("4997e6b2-fbd7-41c3-c193-08dca2b8acce"), new DateTime(2024, 7, 12, 17, 22, 3, 633, DateTimeKind.Unspecified).AddTicks(1632), "Almejas" },
                    { new Guid("4c4bb54b-b566-4323-bb66-08dca2b7c3d6"), new DateTime(2024, 7, 12, 17, 15, 32, 775, DateTimeKind.Unspecified).AddTicks(8302), "Manzana" },
                    { new Guid("50549506-5354-494e-e461-08dca2afc987"), new DateTime(2024, 7, 12, 16, 18, 26, 350, DateTimeKind.Unspecified).AddTicks(4077), "Frijoles" },
                    { new Guid("5e33cd41-61df-4c10-997f-08dca2b4b3ac"), new DateTime(2024, 7, 12, 16, 53, 37, 167, DateTimeKind.Unspecified).AddTicks(540), "Vainas" },
                    { new Guid("6bd3fa32-c0d0-4e59-1b7e-08dca2b527ce"), new DateTime(2024, 7, 12, 16, 56, 52, 4, DateTimeKind.Unspecified).AddTicks(3200), "Harina" },
                    { new Guid("6d5c900e-e3c4-4f19-b502-46525f4d1010"), new DateTime(2024, 7, 14, 1, 20, 13, 446, DateTimeKind.Unspecified).AddTicks(6667), "Cafe" },
                    { new Guid("74982b7e-4d9f-437e-81a2-08dca2b20eff"), new DateTime(2024, 7, 12, 16, 34, 41, 892, DateTimeKind.Unspecified).AddTicks(7646), "Legumbres" },
                    { new Guid("787bb05e-ccb4-49a3-b8e3-5911d6c974bd"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9545), "Tomate" },
                    { new Guid("8254a0a5-efd7-4af7-51f5-08dca29af6fc"), new DateTime(2024, 7, 12, 13, 51, 58, 825, DateTimeKind.Unspecified).AddTicks(2333), "Nachos" },
                    { new Guid("82615949-0575-4305-4339-08dca2b6eba0"), new DateTime(2024, 7, 12, 17, 9, 30, 31, DateTimeKind.Unspecified).AddTicks(7773), "Alcachofa" },
                    { new Guid("827812cc-6062-4236-9716-5205ff4b395a"), new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5571), "Pimienta" },
                    { new Guid("84601fbf-d4b8-49d1-ee1a-08dca2a914ea"), new DateTime(2024, 7, 12, 15, 30, 26, 351, DateTimeKind.Unspecified).AddTicks(5601), "Habichuelas blancas" },
                    { new Guid("886bba2e-9f4e-461d-bf7e-03d8caf8861d"), new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5557), "Limon" },
                    { new Guid("97bd18a8-3cf1-40e3-8426-08dca292b229"), new DateTime(2024, 7, 12, 12, 50, 11, 737, DateTimeKind.Unspecified).AddTicks(9175), "Culcuma" },
                    { new Guid("aac2495d-b422-4dc2-ae14-386b8dcff963"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9587), "Cebolla" },
                    { new Guid("ae2a2a39-68df-4e45-51f4-08dca29af6fc"), new DateTime(2024, 7, 12, 13, 49, 22, 410, DateTimeKind.Unspecified).AddTicks(3141), "Arroz" },
                    { new Guid("b08d05fb-c8fc-4b41-1c27-08dca28e2f3e"), new DateTime(2024, 7, 12, 12, 18, 52, 629, DateTimeKind.Unspecified).AddTicks(8430), "Aguacate" },
                    { new Guid("b860fdaf-5a5c-4d8a-98f4-133f5b71a54a"), new DateTime(2024, 7, 14, 1, 19, 13, 930, DateTimeKind.Unspecified), "Azucar" },
                    { new Guid("c1e7f1b9-c2d2-4cc0-bce8-08dca2b63451"), new DateTime(2024, 7, 12, 17, 4, 22, 491, DateTimeKind.Unspecified).AddTicks(2631), "Espinaca" },
                    { new Guid("c508e170-901c-42c4-fe94-08dca2b08c94"), new DateTime(2024, 7, 12, 16, 23, 53, 595, DateTimeKind.Unspecified).AddTicks(378), "Champiñon" },
                    { new Guid("cb92444a-9c09-477c-9833-c15f1d9cba7b"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9589), "Ajo" },
                    { new Guid("cdf7301a-3ae4-46a9-b29a-08dca29a3744"), new DateTime(2024, 7, 12, 13, 44, 0, 216, DateTimeKind.Unspecified).AddTicks(3531), "Guandules" },
                    { new Guid("d549d72a-af5b-4748-f312-08dca2b8d125"), new DateTime(2024, 7, 12, 17, 23, 4, 602, DateTimeKind.Unspecified).AddTicks(8155), "Fresas" },
                    { new Guid("e4e7cb92-46b7-42aa-accf-5f0a7bd79572"), new DateTime(2024, 7, 11, 10, 48, 44, 126, DateTimeKind.Unspecified).AddTicks(9615), "Pimienta negra" },
                    { new Guid("e5993238-c45e-4734-1c26-08dca28e2f3e"), new DateTime(2024, 7, 12, 12, 17, 54, 110, DateTimeKind.Unspecified).AddTicks(151), "Garbanzos" },
                    { new Guid("e6c873c9-4118-4822-9603-3880f04664d3"), new DateTime(2024, 7, 13, 21, 32, 2, 422, DateTimeKind.Unspecified).AddTicks(5555), "Pepino" },
                    { new Guid("eb619742-b130-455a-69c3-08dca2b712a7"), new DateTime(2024, 7, 12, 17, 10, 35, 508, DateTimeKind.Unspecified).AddTicks(3334), "Ostras" },
                    { new Guid("f37f07b2-823d-41fa-b110-08dca29a128f"), new DateTime(2024, 7, 12, 13, 42, 59, 926, DateTimeKind.Unspecified).AddTicks(9183), "Habichuelas" },
                    { new Guid("f5cbc849-480f-423e-10a1-08dca2b0af35"), new DateTime(2024, 7, 12, 16, 24, 51, 688, DateTimeKind.Unspecified).AddTicks(6872), "Hummus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientsId",
                table: "DishIngredients",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
