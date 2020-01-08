using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class threeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestList_User_UserId",
                table: "GuestList");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestList_Wedding_WeddingId",
                table: "GuestList");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedding_User_UserId",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList");

            migrationBuilder.RenameTable(
                name: "Wedding",
                newName: "Weddings");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "GuestList",
                newName: "GuestLists");

            migrationBuilder.RenameIndex(
                name: "IX_Wedding_UserId",
                table: "Weddings",
                newName: "IX_Weddings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestList_WeddingId",
                table: "GuestLists",
                newName: "IX_GuestLists_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestList_UserId",
                table: "GuestLists",
                newName: "IX_GuestLists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestLists",
                table: "GuestLists",
                column: "GuestListId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestLists_Users_UserId",
                table: "GuestLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestLists_Weddings_WeddingId",
                table: "GuestLists",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestLists_Users_UserId",
                table: "GuestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestLists_Weddings_WeddingId",
                table: "GuestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestLists",
                table: "GuestLists");

            migrationBuilder.RenameTable(
                name: "Weddings",
                newName: "Wedding");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "GuestLists",
                newName: "GuestList");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_UserId",
                table: "Wedding",
                newName: "IX_Wedding_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestLists_WeddingId",
                table: "GuestList",
                newName: "IX_GuestList_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestLists_UserId",
                table: "GuestList",
                newName: "IX_GuestList_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList",
                column: "GuestListId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestList_User_UserId",
                table: "GuestList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestList_Wedding_WeddingId",
                table: "GuestList",
                column: "WeddingId",
                principalTable: "Wedding",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedding_User_UserId",
                table: "Wedding",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
