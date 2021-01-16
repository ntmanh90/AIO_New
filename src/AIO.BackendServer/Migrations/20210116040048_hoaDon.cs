using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class hoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID_HoaDon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    ID_HinhThucThanhToan = table.Column<int>(nullable: false),
                    ID_NgonNgu = table.Column<string>(maxLength: 10, nullable: false),
                    MaHoaDon = table.Column<string>(maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    SoTienThanhToan = table.Column<float>(nullable: false),
                    ThoiGianDen = table.Column<DateTime>(nullable: false),
                    MoTa = table.Column<string>(nullable: false),
                    Link = table.Column<string>(maxLength: 1000, nullable: false),
                    DaPhanHoi = table.Column<bool>(nullable: false),
                    DaThanhToan = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID_HoaDon);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDon");
        }
    }
}
