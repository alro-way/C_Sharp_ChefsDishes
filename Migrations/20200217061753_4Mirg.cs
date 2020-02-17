using Microsoft.EntityFrameworkCore.Migrations;

namespace C_Sharp_ChefsDishes.Migrations
{
    public partial class _4Mirg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Chefs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Chefs");
        }
    }
}
