using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class khuyenmaidatphong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuyenMaiDatPhong",
                columns: table => new
                {
                    ID_KhuyenMaiDatPhong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    MaKhuyenMaiDatPhong = table.Column<string>(maxLength: 50, nullable: false),
                    TenKhuyenMaiDatPhong = table.Column<string>(maxLength: 300, nullable: false),
                    SoNgayLuuTruToiThieu = table.Column<int>(maxLength: 500, nullable: false),
                    SoNgayDatTruoc = table.Column<int>(nullable: false),
                    GiaCongThem = table.Column<float>(nullable: false),
                    PhanTramGiamGia = table.Column<float>(nullable: false),
                    PhanTramDatCoc = table.Column<float>(nullable: false),
                    BaoGomAnSang = table.Column<bool>(nullable: false),
                    DuocPhepHuy = table.Column<bool>(nullable: false),
                    DuocPhepThayDoi = table.Column<bool>(nullable: false),
                    NgayBatDau = table.Column<DateTime>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false),
                    TatCaNgayTrongTuan = table.Column<bool>(nullable: false),
                    ThuHai = table.Column<bool>(nullable: false),
                    ThuBa = table.Column<bool>(nullable: false),
                    ThuTu = table.Column<bool>(nullable: false),
                    ThuNam = table.Column<bool>(nullable: false),
                    ThuSau = table.Column<bool>(nullable: false),
                    ThuBay = table.Column<bool>(nullable: false),
                    ChuNhat = table.Column<bool>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiDatPhong", x => x.ID_KhuyenMaiDatPhong);
                });

            migrationBuilder.CreateTable(
                name: "NN_KhuyenMaiDatPhong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_KhuyenMaiDatPhong = table.Column<int>(nullable: false),
                    TenTheoNgonNgu = table.Column<string>(maxLength: 300, nullable: false),
                    DieuKhoan_DieuKien = table.Column<string>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_KhuyenMaiDatPhong", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhuyenMaiDatPhong");

            migrationBuilder.DropTable(
                name: "NN_KhuyenMaiDatPhong");
        }
    }
}
