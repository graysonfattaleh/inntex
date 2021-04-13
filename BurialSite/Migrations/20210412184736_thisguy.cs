using Microsoft.EntityFrameworkCore.Migrations;

namespace BurialSite.Migrations
{
    public partial class thisguy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurialFileUrl");

            migrationBuilder.AddColumn<int>(
                name: "BurialID",
                table: "FileUrls",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Burials",
                type: "text",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileUrls_BurialID",
                table: "FileUrls",
                column: "BurialID");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUrls_Burials_BurialID",
                table: "FileUrls",
                column: "BurialID",
                principalTable: "Burials",
                principalColumn: "BurialID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUrls_Burials_BurialID",
                table: "FileUrls");

            migrationBuilder.DropIndex(
                name: "IX_FileUrls_BurialID",
                table: "FileUrls");

            migrationBuilder.DropColumn(
                name: "BurialID",
                table: "FileUrls");

            migrationBuilder.AlterColumn<char>(
                name: "Sex",
                table: "Burials",
                type: "character(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BurialFileUrl",
                columns: table => new
                {
                    BurialID = table.Column<int>(type: "integer", nullable: false),
                    FileUrlId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialFileUrl", x => new { x.BurialID, x.FileUrlId });
                    table.ForeignKey(
                        name: "FK_BurialFileUrl_Burials_BurialID",
                        column: x => x.BurialID,
                        principalTable: "Burials",
                        principalColumn: "BurialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurialFileUrl_FileUrls_FileUrlId",
                        column: x => x.FileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "FileUrlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BurialFileUrl_FileUrlId",
                table: "BurialFileUrl",
                column: "FileUrlId");
        }
    }
}
