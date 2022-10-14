using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CompanyCoefs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyLastUpdateDate",
                table: "Coefs",
                newName: "CoefLastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "CompanyCreateDate",
                table: "Coefs",
                newName: "CoefCreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoefLastUpdateDate",
                table: "Coefs",
                newName: "CompanyLastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "CoefCreateDate",
                table: "Coefs",
                newName: "CompanyCreateDate");
        }
    }
}
