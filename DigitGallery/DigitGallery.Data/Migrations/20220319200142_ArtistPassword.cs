using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitGallery.Data.Migrations
{
    public partial class ArtistPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Artists");
        }
    }
}
