using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class DatosSemilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroEncargue",
                table: "encargues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Horario",
                columns: new[] { "Id", "Dia", "HoraApertura", "HoraCierre", "NegocioId" },
                values: new object[,]
                {
                    { 1, "Lunes", "11:00", "23:00", null },
                    { 2, "Martes", "11:00", "23:00", null },
                    { 3, "Miércoles", "11:00", "23:00", null },
                    { 4, "Jueves", "11:00", "23:00", null },
                    { 5, "Viernes", "11:00", "00:00", null },
                    { 6, "Sábado", "11:00", "00:00", null },
                    { 7, "Domingo", "11:00", "22:00", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "NumeroEncargue",
                table: "encargues");
        }
    }
}
