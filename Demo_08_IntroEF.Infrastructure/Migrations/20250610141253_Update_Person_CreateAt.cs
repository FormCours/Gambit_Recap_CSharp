using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_08_IntroEF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Person_CreateAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Person",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION set_create_at_person()
                RETURNS TRIGGER AS $$
                BEGIN
                    NEW.""CreateAt"" = NOW();
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER person_create_at_trigger
                BEFORE INSERT ON ""Person""
                FOR EACH ROW
                EXECUTE FUNCTION set_create_at_person();
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER person_create_at_trigger");
            migrationBuilder.Sql("DROP FUNCTION set_create_at_person");
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Person");
        }
    }
}
