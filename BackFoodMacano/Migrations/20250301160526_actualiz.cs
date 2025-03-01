using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackFoodMacano.Migrations
{
    /// <inheritdoc />
    public partial class actualiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=036cfd9a-89b9-44a0-b97f-c87af5398706");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburquesoo.png?alt=media&token=21d2b902-5f75-49cb-aa0d-7b91555ab1b3");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhamurchedarr.png?alt=media&token=a6716fc2-965a-4b63-9e06-16ef5b3e194f");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=036cfd9a-89b9-44a0-b97f-c87af5398706");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburquesoo.png?alt=media&token=21d2b902-5f75-49cb-aa0d-7b91555ab1b3");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaquee.png?alt=media&token=46ea6c8d-fe58-469f-9c4e-0646cdaa5a4f");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaeslomm.png?alt=media&token=5312dcbb-3365-40e3-87d1-92ce5ce7056c");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaquee.png?alt=media&token=46ea6c8d-fe58-469f-9c4e-0646cdaa5a4f");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcocaa.png?alt=media&token=46e172b8-a890-49dc-b2d6-841e327c6fda");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Faguaa.png?alt=media&token=b9677456-0259-47c6-91ec-8f33136c9ab8");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoptell.png?alt=media&token=4b440890-37ca-4bae-aadc-3e8656d22940");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcocaa.png?alt=media&token=46e172b8-a890-49dc-b2d6-841e327c6fda");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Faguaa.png?alt=media&token=b9677456-0259-47c6-91ec-8f33136c9ab8");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamitaa.png?alt=media&token=c0a6c4ba-d232-4fe6-9ce7-f8d9a21ffdaa");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizappp.png?alt=media&token=d2d21eb8-bd62-4593-a64c-dfe2b5676244");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizas.png?alt=media&token=6e337a8e-bf33-40db-ba97-02c1c0e3ef7c");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamitaa.png?alt=media&token=c0a6c4ba-d232-4fe6-9ce7-f8d9a21ffdaa");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizappp.png?alt=media&token=d2d21eb8-bd62-4593-a64c-dfe2b5676244");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "usuarios");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburqueso.png?alt=media&token=0c9d6309-e1df-4a6c-ae52-4af835a1a291");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=d43a0f98-591d-4325-b410-299dbb2da279");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhamurchedar.png?alt=media&token=b8c4f465-7b9f-46fa-b3c2-c7c035fff6a3");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2FHaburqueso.png?alt=media&token=0c9d6309-e1df-4a6c-ae52-4af835a1a291");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FHamburguesa%2Fhabur.png?alt=media&token=d43a0f98-591d-4325-b410-299dbb2da279");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaeslom.png?alt=media&token=7b4c522e-3473-483c-9cb8-9a66fe59c83a");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaque.jpg?alt=media&token=70219250-edd3-43ec-aed2-52a189d45c00");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FSanguches%2Fmilaeslom.png?alt=media&token=7b4c522e-3473-483c-9cb8-9a66fe59c83a");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fagua.jpg?alt=media&token=d18faac5-b227-43e4-aa5a-5bf6fdfce40f");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoca.jpeg?alt=media&token=d364cef2-8a4d-4756-83b3-adb1bb259c22");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoptel.png?alt=media&token=1f8e271a-efeb-4f70-9f5f-ee00a2a27e8f");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fagua.jpg?alt=media&token=d18faac5-b227-43e4-aa5a-5bf6fdfce40f");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FBebidas%2Fcoca.jpeg?alt=media&token=d364cef2-8a4d-4756-83b3-adb1bb259c22");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamita.png?alt=media&token=5acd1c05-40ab-4447-af38-2874e93540e4");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizapp.jpeg?alt=media&token=1a33825e-b383-4b66-a5d5-9f3ad98977fe");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizaques.avif?alt=media&token=c31eacc9-9f21-403b-be71-b6a0df74a858");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizas.png?alt=media&token=6e337a8e-bf33-40db-ba97-02c1c0e3ef7c");

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImagenUrl",
                value: "https://firebasestorage.googleapis.com/v0/b/foodmacano.appspot.com/o/img%2FPizas%2Fpizamita.png?alt=media&token=5acd1c05-40ab-4447-af38-2874e93540e4");
        }
    }
}
