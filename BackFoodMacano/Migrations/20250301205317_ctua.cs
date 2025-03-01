using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class ctua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MapaIframe",
                value: "<iframe \r\n    src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d27671.94929510676!2d-60.304126219719706!3d-29.893283243730366!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944bbec37fa30239%3A0x363b55a9e714bf24!2sCalchaqu%C3%AD%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740862222458!5m2!1ses-419!2sar\" \r\n    width=\"100%\" \r\n    height=\"450\" \r\n    style=\"border:0;\" \r\n    allowfullscreen=\"\" \r\n    loading=\"lazy\" \r\n    referrerpolicy=\"no-referrer-when-downgrade\">\r\n</iframe>\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MapaIframe",
                value: "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3459.2046380850775!2d-60.286982767738394!3d-29.887203614077283!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944bbec37fa30239%3A0x363b55a9e714bf24!2sCalchaqu%C3%AD%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1740498914063!5m2!1ses-419!2sar\"></iframe>");
        }
    }
}
