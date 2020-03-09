using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haandvaerker",
                columns: table => new
                {
                    HaandvaerkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HVAnsaettelsesdato = table.Column<DateTime>(nullable: false),
                    HVEfternavn = table.Column<string>(nullable: true),
                    HVFagomraade = table.Column<string>(nullable: true),
                    HVFornavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haandvaerker", x => x.HaandvaerkerId);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejskasse",
                columns: table => new
                {
                    VTKId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VTKAnskaffet = table.Column<DateTime>(nullable: false),
                    VTKEjesAf = table.Column<int>(nullable: false),
                    VTKfabrikat = table.Column<string>(nullable: true),
                    VTKFarve = table.Column<string>(nullable: true),
                    VTKModel = table.Column<string>(nullable: true),
                    VTKSerienummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejskasse", x => x.VTKId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejskasse_Haandvaerker_VTKEjesAf",
                        column: x => x.VTKEjesAf,
                        principalTable: "Haandvaerker",
                        principalColumn: "HaandvaerkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoej",
                columns: table => new
                {
                    VTId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiggerIVTK = table.Column<int>(nullable: false),
                    VTAnskaffet = table.Column<DateTime>(nullable: false),
                    VTFabrikat = table.Column<string>(nullable: true),
                    VTModel = table.Column<string>(nullable: true),
                    VTSerienummer = table.Column<string>(nullable: true),
                    VTType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoej", x => x.VTId);
                    table.ForeignKey(
                        name: "FK_Vaerktoej_Vaerktoejskasse_LiggerIVTK",
                        column: x => x.LiggerIVTK,
                        principalTable: "Vaerktoejskasse",
                        principalColumn: "VTKId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoej_LiggerIVTK",
                table: "Vaerktoej",
                column: "LiggerIVTK");

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejskasse_VTKEjesAf",
                table: "Vaerktoejskasse",
                column: "VTKEjesAf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaerktoej");

            migrationBuilder.DropTable(
                name: "Vaerktoejskasse");

            migrationBuilder.DropTable(
                name: "Haandvaerker");
        }
    }
}
