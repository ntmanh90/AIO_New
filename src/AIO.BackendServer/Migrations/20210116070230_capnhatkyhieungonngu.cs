using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class capnhatkyhieungonngu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_NgonNgu",
                table: "HoaDon");

            migrationBuilder.AddColumn<string>(
                name: "KyHieuNgonNgu",
                table: "HoaDon",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KyHieuNgonNgu",
                table: "HoaDon");

            migrationBuilder.AddColumn<string>(
                name: "ID_NgonNgu",
                table: "HoaDon",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
