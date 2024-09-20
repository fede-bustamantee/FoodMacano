using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class mascambiosDat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "redesSociales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Instagram = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Facebook = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Whatsapp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redesSociales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "negocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Horario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MapaIframe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RedesSocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_negocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_negocios_redesSociales_RedesSocialId",
                        column: x => x.RedesSocialId,
                        principalTable: "redesSociales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "redesSociales",
                columns: new[] { "Id", "Facebook", "Instagram", "Whatsapp" },
                values: new object[] { 1, "https://www.facebook.com", "https://www.instagram.com", "https://wa.me/543498409675" });

            migrationBuilder.InsertData(
                table: "negocios",
                columns: new[] { "Id", "Direccion", "Horario", "MapaIframe", "Nombre", "RedesSocialId", "Telefono" },
                values: new object[] { 1, "Calle Falsa 123, Ciudad Ejemplo", "Lunes a Viernes 9:00 AM - 6:00 PM", "<iframe class=\"map\" src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d27541.325671616178!2d-60.439340636223776!3d-30.360449115325437!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944b0554d0eb3903%3A0x7b078fba72f704b!2sGdor.%20Crespo%2C%20Santa%20Fe!5e0!3m2!1ses!2sar!4v1725375616155!5m2!1ses!2sar\" width=\"100%\" height=\"275\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano", 1, "123456789" });

            migrationBuilder.CreateIndex(
                name: "IX_negocios_RedesSocialId",
                table: "negocios",
                column: "RedesSocialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "negocios");

            migrationBuilder.DropTable(
                name: "redesSociales");
        }
    }
}
