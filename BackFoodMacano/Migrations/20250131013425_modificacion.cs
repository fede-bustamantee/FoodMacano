using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class modificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MapaIframe",
                value: "<iframe class=\"map\" src=\"https://www.google.com/maps/place/Gdor.+Crespo,+Santa+Fe/@-30.3611856,-60.4003288,16z/data=!4m6!3m5!1s0x944b0554d0eb3903:0x7b078fba72f704b!8m2!3d-30.3620638!4d-60.4020713!16s%2Fg%2F120y82vp?entry=ttu&g_ep=EgoyMDI1MDEyOC4wIKXMDSoASAFQAw%3D%3D\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "negocios",
                keyColumn: "Id",
                keyValue: 1,
                column: "MapaIframe",
                value: "<iframe class=\"map\" src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d27541.325671616178!2d-60.439340636223776!3d-30.360449115325437!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x944b0554d0eb3903%3A0x7b078fba72f704b!2sGdor.%20Crespo%2C%20Santa%20Fe!5e0!3m2!1ses!2sar!4v1725375616155!5m2!1ses!2sar\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>");
        }
    }
}
