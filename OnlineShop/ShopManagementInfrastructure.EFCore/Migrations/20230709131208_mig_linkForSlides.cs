using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagementInfrastructure.EFCore.Migrations
{
    public partial class mig_linkForSlides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Slides");
        }
    }
}
