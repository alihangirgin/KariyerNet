using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerNet.Data.Migrations
{
    public partial class jobAdvPublishDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "JobAdvertisements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "JobAdvertisements");
        }
    }
}
