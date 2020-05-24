using Microsoft.EntityFrameworkCore.Migrations;

namespace MoscowM.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InOutMetros",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MetroStation = table.Column<string>(nullable: true),
                    MetroLine = table.Column<string>(nullable: true),
                    Schedule1 = table.Column<string>(nullable: true),
                    Schedule2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOutMetros", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InOutMetros",
                columns: new[] { "Id", "MetroLine", "MetroStation", "Name", "Schedule1", "Schedule2" },
                values: new object[] { 1L, "Калужско-Рижская линия  ", "Китай-город  ", "Китай-город, вход-выход 9 в северный вестибюль", "Режим работы по нечётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  ", "Режим работы по чётным дням: открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:24  " });

            migrationBuilder.InsertData(
                table: "InOutMetros",
                columns: new[] { "Id", "MetroLine", "MetroStation", "Name", "Schedule1", "Schedule2" },
                values: new object[] { 2L, "Калужско-Рижская линия ", "Китай-город ", "Китай-город, вход-выход 5 в северный вестибюль", "Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:43:05, по 2 пути в 05:49:50; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16", "Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:44:00, по 2 пути в 05:49:05; последний поезд по 1 пути в 01:36:20, по 2 пути в 01:27:16 " });

            migrationBuilder.InsertData(
                table: "InOutMetros",
                columns: new[] { "Id", "MetroLine", "MetroStation", "Name", "Schedule1", "Schedule2" },
                values: new object[] { 3L, "Люблинско-Дмитровская линия", "Братиславская  ", "Братиславская, вход-выход 5 в северный вестибюль", "Режим работы по нечётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 05:56:00, по 2 пути в 05:42:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00  ", "Режим работы по чётным дням:  открытие в 05:30:00; закрытие в 01:00:00; первый поезд по 1 пути в 06:00:00, по 2 пути в 05:49:00; последний поезд по 1 пути в 01:52:00, по 2 пути в 01:12:00 " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InOutMetros");
        }
    }
}
