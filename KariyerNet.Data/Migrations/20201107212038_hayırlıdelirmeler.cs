using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerNet.Data.Migrations
{
    public partial class hayırlıdelirmeler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departmants_AspNetUsers_UserId1",
                table: "Departmants");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_AspNetUsers_UserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_UserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_Departmants_UserId1",
                table: "Departmants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JobAdvertisements");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Departmants");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Departmants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_CompanyUserId",
                table: "JobAdvertisements",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_UserId",
                table: "Departmants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmants_AspNetUsers_UserId",
                table: "Departmants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_AspNetUsers_CompanyUserId",
                table: "JobAdvertisements",
                column: "CompanyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departmants_AspNetUsers_UserId",
                table: "Departmants");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_AspNetUsers_CompanyUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_CompanyUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_Departmants_UserId",
                table: "Departmants");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "JobAdvertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Departmants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Departmants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_UserId",
                table: "JobAdvertisements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_UserId1",
                table: "Departmants",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmants_AspNetUsers_UserId1",
                table: "Departmants",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_AspNetUsers_UserId",
                table: "JobAdvertisements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
