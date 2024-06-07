using Microsoft.EntityFrameworkCore.Migrations;

namespace HKCBusbarInspection.Migrations.검사결과테이블Migrations
{
    public partial class AddShuttle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ilshu",
                schema: "public",
                table: "inspl",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ilshu",
                schema: "public",
                table: "inspl");
        }
    }
}
