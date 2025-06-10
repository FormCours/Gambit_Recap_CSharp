using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_08_IntroEF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_CheckContraint_PetName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_My_Pet__Min_Name",
                table: "My_Pet");

            migrationBuilder.AddCheckConstraint(
                name: "CK_My_Pet__Min_Name",
                table: "My_Pet",
                sql: "LENGTH(\"Name\") > 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_My_Pet__Min_Name",
                table: "My_Pet");

            migrationBuilder.AddCheckConstraint(
                name: "CK_My_Pet__Min_Name",
                table: "My_Pet",
                sql: "LENGTH(\"Name\") > 3");
        }
    }
}
