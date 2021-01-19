using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerNet.Data.Migrations
{
    public partial class userNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "UserDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "UserDetails");
        }
    }
}
