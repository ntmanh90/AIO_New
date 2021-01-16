using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class CaiDatBanPhong_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "KhuyenMaiDatPhong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "DichVu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LoaiPhong_KhuyenMaiDatPhong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_LoaiPhong = table.Column<int>(nullable: false),
                    ID_KhuyenMaiDatPhong = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(maxLength: 300, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong_KhuyenMaiDatPhong", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiPhong_KhuyenMaiDatPhong");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "KhuyenMaiDatPhong");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "DichVu");
        }
    }
}
