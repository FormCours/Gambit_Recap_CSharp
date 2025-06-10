using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_08_IntroEF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddData_Demo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DemoEF",
                columns: new[] { "Id", "Desc", "IsActive", "Name" },
                values: new object[] { 1, "Exemple de Seed data", true, "Ex1" });

            migrationBuilder.InsertData(
                table: "DemoEF",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[] { 2, "Encore plus :o", "Ex2" });

            migrationBuilder.InsertData(
                table: "DemoEF",
                columns: new[] { "Id", "Desc", "IsActive", "Name" },
                values: new object[,]
                {
                    { 3, null, true, "Nullable" },
                    { 4, "Fin de l'exemple !", true, "Ex3" }
                });


            // Si besoin de modifier la sequence d'id, utiliser cette commande en PostgreSQL
            // -> SELECT setval('table_id_seq', 42, FALSE);
            // https://www.postgresql.org/docs/current/functions-sequence.html
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DemoEF",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DemoEF",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DemoEF",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DemoEF",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
