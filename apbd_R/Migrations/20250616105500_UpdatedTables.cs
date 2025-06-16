using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbdR.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpacks_Characters_CharacterId",
                table: "Backpacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Backpacks_Items_ItemId",
                table: "Backpacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Title_Characters_CharacterId",
                table: "Character_Title");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Title_Titles_TitleId",
                table: "Character_Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Titles",
                table: "Titles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backpacks",
                table: "Backpacks");

            migrationBuilder.RenameTable(
                name: "Titles",
                newName: "Title");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameTable(
                name: "Backpacks",
                newName: "Backpack");

            migrationBuilder.RenameIndex(
                name: "IX_Backpacks_ItemId",
                table: "Backpack",
                newName: "IX_Backpack_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Title",
                table: "Title",
                column: "TitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backpack",
                table: "Backpack",
                columns: new[] { "CharacterId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Backpack_Character_CharacterId",
                table: "Backpack",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Backpack_Item_ItemId",
                table: "Backpack",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Title_Character_CharacterId",
                table: "Character_Title",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Title_Title_TitleId",
                table: "Character_Title",
                column: "TitleId",
                principalTable: "Title",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpack_Character_CharacterId",
                table: "Backpack");

            migrationBuilder.DropForeignKey(
                name: "FK_Backpack_Item_ItemId",
                table: "Backpack");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Title_Character_CharacterId",
                table: "Character_Title");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Title_Title_TitleId",
                table: "Character_Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Title",
                table: "Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backpack",
                table: "Backpack");

            migrationBuilder.RenameTable(
                name: "Title",
                newName: "Titles");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameTable(
                name: "Backpack",
                newName: "Backpacks");

            migrationBuilder.RenameIndex(
                name: "IX_Backpack_ItemId",
                table: "Backpacks",
                newName: "IX_Backpacks_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Titles",
                table: "Titles",
                column: "TitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backpacks",
                table: "Backpacks",
                columns: new[] { "CharacterId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Backpacks_Characters_CharacterId",
                table: "Backpacks",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Backpacks_Items_ItemId",
                table: "Backpacks",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Title_Characters_CharacterId",
                table: "Character_Title",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Title_Titles_TitleId",
                table: "Character_Title",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
