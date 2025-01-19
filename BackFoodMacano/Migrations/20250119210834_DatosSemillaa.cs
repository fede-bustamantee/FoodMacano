using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class DatosSemillaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "negocios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Horario",
                value: "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario",
                table: "negocios");

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraApertura = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraCierre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NegocioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horario_negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "negocios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Horario_NegocioId",
                table: "Horario",
                column: "NegocioId");
        }
    }
}
