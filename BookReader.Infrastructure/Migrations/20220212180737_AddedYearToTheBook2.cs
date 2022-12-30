using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Infrastructure.Migrations
{
    public partial class AddedYearToTheBook2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Books");
        }
    }
}
