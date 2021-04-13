using Microsoft.EntityFrameworkCore.Migrations;

namespace BurialSite.Migrations
{
    public partial class thisguytwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUrls_Burials_BurialID",
                table: "FileUrls");

            migrationBuilder.AlterColumn<int>(
                name: "BurialID",
                table: "FileUrls",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileUrls_Burials_BurialID",
                table: "FileUrls",
                column: "BurialID",
                principalTable: "Burials",
                principalColumn: "BurialID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUrls_Burials_BurialID",
                table: "FileUrls");

            migrationBuilder.AlterColumn<int>(
                name: "BurialID",
                table: "FileUrls",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUrls_Burials_BurialID",
                table: "FileUrls",
                column: "BurialID",
                principalTable: "Burials",
                principalColumn: "BurialID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
