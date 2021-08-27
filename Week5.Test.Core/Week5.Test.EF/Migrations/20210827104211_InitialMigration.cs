using Microsoft.EntityFrameworkCore.Migrations;

namespace Week5.Test.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piatto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipologia = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruolo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Piatto",
                columns: new[] { "Id", "Descrizione", "Nome", "Prezzo", "Tipologia" },
                values: new object[,]
                {
                    { 1, "Tradizionale piatto italiano", "Lasagne", 12m, 0 },
                    { 2, "Bistecca da allevamenti italiani", "Bistecca", 20m, 1 },
                    { 3, "Insalata con foglie italiane", "Insalata", 4m, 2 },
                    { 4, "Dolce italiano fatto da italiani", "Tiramisù", 6m, 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Ruolo", "Username" },
                values: new object[,]
                {
                    { 1, "1234", 1, "giulia.tuttobene@abc.it" },
                    { 2, "4321", 0, "m.rossi@abc.it" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatto");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
