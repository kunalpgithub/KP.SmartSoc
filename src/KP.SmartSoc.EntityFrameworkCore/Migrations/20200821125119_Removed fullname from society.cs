using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.SmartSoc.Migrations
{
    public partial class Removedfullnamefromsociety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AbpTenants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
