using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class ModelNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsers_AspNetUsers_CollectorId",
                table: "IdentityUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsers_Books_BookId",
                table: "IdentityUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUsers",
                table: "IdentityUsers");

            migrationBuilder.RenameTable(
                name: "IdentityUsers",
                newName: "IdentityUsersBooks");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUsers_BookId",
                table: "IdentityUsersBooks",
                newName: "IX_IdentityUsersBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUsersBooks",
                table: "IdentityUsersBooks",
                columns: new[] { "CollectorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersBooks_AspNetUsers_CollectorId",
                table: "IdentityUsersBooks",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersBooks_Books_BookId",
                table: "IdentityUsersBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersBooks_AspNetUsers_CollectorId",
                table: "IdentityUsersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersBooks_Books_BookId",
                table: "IdentityUsersBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUsersBooks",
                table: "IdentityUsersBooks");

            migrationBuilder.RenameTable(
                name: "IdentityUsersBooks",
                newName: "IdentityUsers");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUsersBooks_BookId",
                table: "IdentityUsers",
                newName: "IX_IdentityUsers_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUsers",
                table: "IdentityUsers",
                columns: new[] { "CollectorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsers_AspNetUsers_CollectorId",
                table: "IdentityUsers",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsers_Books_BookId",
                table: "IdentityUsers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
