using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Department_HW_.Data.Migrations
{
    public partial class MilDocMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MillitaryDocument",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MillitaryDocument",
                table: "Workers");
        }
    }
}
