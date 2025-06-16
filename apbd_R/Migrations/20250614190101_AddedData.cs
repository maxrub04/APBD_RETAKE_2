using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbdR.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backpacks",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpacks", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Backpacks_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpacks_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character_Title",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Title", x => new { x.CharacterId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_Character_Title_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Title_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 43, "John", "Yakuza", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Item1", 10 },
                    { 2, "Item2", 11 },
                    { 3, "Item3", 12 },
                    { 4, "Item4", 5 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "TitleId", "Name" },
                values: new object[,]
                {
                    { 1, "Title1" },
                    { 2, "Title2" },
                    { 3, "Title3" }
                });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 2, 1 },
                    { 1, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Character_Title",
                columns: new[] { "CharacterId", "TitleId", "AcquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_ItemId",
                table: "Backpacks",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Title_TitleId",
                table: "Character_Title",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpacks");

            migrationBuilder.DropTable(
                name: "Character_Title");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 3);
        }
    }
}
