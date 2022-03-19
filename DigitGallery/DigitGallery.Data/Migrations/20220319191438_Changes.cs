using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitGallery.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Artists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Artists",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }
    }
}
