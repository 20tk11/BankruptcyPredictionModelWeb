using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CompanyCoefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coefs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FinancialYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Audit = table.Column<int>(type: "INTEGER", nullable: false),
                    FinancialYearsTillBankruptcy = table.Column<int>(type: "INTEGER", nullable: true),
                    SingleShareholder = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfEntries = table.Column<int>(type: "INTEGER", nullable: false),
                    FinancialReportLate = table.Column<int>(type: "INTEGER", nullable: false),
                    FinancialReportEstablishmentYear = table.Column<int>(type: "INTEGER", nullable: false),
                    NOR_1B_1 = table.Column<double>(type: "REAL", nullable: true),
                    NOR_1B_2 = table.Column<double>(type: "REAL", nullable: true),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyCreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyLastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coefs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coefs_CompanyId",
                table: "Coefs",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coefs");
        }
    }
}
