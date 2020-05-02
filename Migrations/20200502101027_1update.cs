using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolsPortal.Migrations
{
    public partial class _1update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Des",
                table: "AboutUses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AboutUses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Des",
                table: "AboutUses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AboutUses");
        }
    }
}
