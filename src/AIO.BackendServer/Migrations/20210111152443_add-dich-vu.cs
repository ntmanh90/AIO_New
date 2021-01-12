using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class adddichvu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    ID_DichVu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    MaDichVu = table.Column<string>(maxLength: 50, nullable: false),
                    TenDichvu = table.Column<string>(maxLength: 300, nullable: false),
                    AnhDaiDien = table.Column<string>(maxLength: 500, nullable: false),
                    GiaTinhTheo = table.Column<int>(nullable: false),
                    GiaTheoDichVu = table.Column<float>(nullable: false),
                    GiaTheoDemLuuTru = table.Column<float>(nullable: false),
                    GiaTheoNguoiLon = table.Column<float>(nullable: false),
                    GiaTheoTreEm = table.Column<float>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.ID_DichVu);
                });

            migrationBuilder.CreateTable(
                name: "NN_DichVu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_DichVu = table.Column<int>(nullable: false),
                    TenTheoNgonNgu = table.Column<string>(maxLength: 300, nullable: false),
                    NoiDungTheoNgonNgu = table.Column<string>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_DichVu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "NN_DichVu");
        }
    }
}
