using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Department_HW_.Data.Migrations
{
    public partial class NewDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BachelorGrade",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PasportSerial",
                table: "Workers",
                type: "int",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RKNOPP",
                table: "Workers",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalECTS",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BachelorGrade",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "PasportSerial",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "RKNOPP",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TotalECTS",
                table: "Workers");
        }
    }
}
