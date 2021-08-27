using Microsoft.EntityFrameworkCore.Migrations;

namespace Week5.Test.EF.Migrations
{
    public partial class FixedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Piatto",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tipologia",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Piatto",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tipologia",
                value: 2);
        }
    }
}
