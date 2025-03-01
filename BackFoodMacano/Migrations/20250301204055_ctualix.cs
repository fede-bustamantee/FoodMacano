using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class ctualix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MapaIframe",
                value: "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3459.2046380850775!2d-60.286982767738394!3d-29.887203614077283!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944bbec37fa30239%3A0x363b55a9e714bf24!2sCalchaqu%C3%AD%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740498914063!5m2!1ses-419!2sar\"style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MapaIframe",
                value: "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3459.2046380850775!2d-60.286982767738394!3d-29.887203614077283!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944bbec37fa30239%3A0x363b55a9e714bf24!2sCalchaqu%C3%AD%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740498914063!5m2!1ses-419!2sar\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>");

            migrationBuilder.InsertData(
                table: "negocios",
                columns: new[] { "Id", "Direccion", "Horario", "MapaIframe", "Nombre", "RedesSocialId", "Telefono" },
                values: new object[,]
                {
                    { 2, "Belgrano 329, Gobernador Crespo", "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00", "<iframe class=\"map\" src=\"https://www.google.com/maps/place/Gdor.+Crespo,+Santa+Fe/@-30.3611856,-60.4003288,16z/data=!4m6!3m5!1s0x944b0554d0eb3903:0x7b078fba72f704b!8m2!3d-30.3620638!4d-60.4020713!16s%2Fg%2F120y82vp?entry=ttu&g_ep=EgoyMDI1MDEyOC4wIKXMDSoASAFQAw%3D%3D\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano, Restaurante 01", 1, "3498756567" },
                    { 3, "San Juan 329, Vera y Pintado", "Lunes a Viernes: 11:00 - 23:00\nSábado: 11:00 - 00:00\nDomingo: 11:00 - 22:00", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6900.601861528618!2d-60.34531971028043!3d-30.142811221417357!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944ba702b3cb97c3%3A0xfab9b5972c337c1b!2sVera%20y%20Pintado%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740498816032!5m2!1ses-419!2sar\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>", "Food Macano, Restaurante 02", 1, "3498756569" }
                });
        }
    }
}
