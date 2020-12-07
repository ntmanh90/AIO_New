using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Data.Migrations
{
    public partial class addrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropColumn(
                name: "NumberOfKnowledgeBases",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumberOfReports",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CauHinhKhachSan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyHieuDatPhong = table.Column<string>(maxLength: 200, nullable: false),
                    EmailNhanPhong = table.Column<string>(maxLength: 200, nullable: false),
                    EmailNhanThongBao = table.Column<string>(maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhKhachSan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CongTy",
                columns: table => new
                {
                    ID_CongTy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTy = table.Column<string>(maxLength: 200, nullable: false),
                    DiaChiCongTy = table.Column<string>(maxLength: 200, nullable: true),
                    MaCongTy = table.Column<string>(maxLength: 50, nullable: false),
                    EmailCongTy = table.Column<string>(maxLength: 200, nullable: false),
                    AnhDaiDien = table.Column<string>(maxLength: 200, nullable: true),
                    NguoiDaiDien = table.Column<string>(maxLength: 200, nullable: false),
                    Hotline = table.Column<string>(maxLength: 200, nullable: false),
                    DienThoaiBan = table.Column<string>(maxLength: 200, nullable: true),
                    SoDiDong = table.Column<string>(maxLength: 200, nullable: true),
                    Note = table.Column<string>(maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTy", x => x.ID_CongTy);
                });

            migrationBuilder.CreateTable(
                name: "Giuong",
                columns: table => new
                {
                    ID_LoaiGiuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giuong", x => x.ID_LoaiGiuong);
                });

            migrationBuilder.CreateTable(
                name: "KhachSan",
                columns: table => new
                {
                    ID_KhachSan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    TenKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    LogoKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    Hotline = table.Column<string>(maxLength: 200, nullable: true),
                    SoDiDong = table.Column<string>(maxLength: 50, nullable: false),
                    SoMayBan = table.Column<string>(maxLength: 200, nullable: true),
                    SoFax = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    DiaChiKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    Website = table.Column<string>(maxLength: 200, nullable: true),
                    Facebook = table.Column<string>(maxLength: 200, nullable: true),
                    Twitter = table.Column<string>(maxLength: 2000, nullable: true),
                    Youtube = table.Column<string>(maxLength: 2000, nullable: true),
                    Instagram = table.Column<string>(maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true),
                    GioiThieu = table.Column<string>(maxLength: 200, nullable: true),
                    ViTri = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachSan", x => x.ID_KhachSan);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiPhongTV = table.Column<string>(maxLength: 200, nullable: false),
                    TenLoaiPhongTA = table.Column<string>(maxLength: 200, nullable: false),
                    LogoKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    Hotline = table.Column<string>(maxLength: 200, nullable: true),
                    SoDiDong = table.Column<string>(maxLength: 50, nullable: false),
                    SoMayBan = table.Column<string>(maxLength: 200, nullable: true),
                    SoFax = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    DiaChiKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    Website = table.Column<string>(maxLength: 200, nullable: true),
                    Facebook = table.Column<string>(maxLength: 200, nullable: true),
                    Twitter = table.Column<string>(maxLength: 2000, nullable: true),
                    Youtube = table.Column<string>(maxLength: 2000, nullable: true),
                    Instagram = table.Column<string>(maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NgonNgu",
                columns: table => new
                {
                    ID_NgonNgu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNgonNgu = table.Column<string>(maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgonNgu", x => x.ID_NgonNgu);
                });

            migrationBuilder.CreateTable(
                name: "NgonNgu_KhachSan",
                columns: table => new
                {
                    ID_KhachSan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    MacDinh = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgonNgu_KhachSan", x => x.ID_KhachSan);
                });

            migrationBuilder.CreateTable(
                name: "NN_KhachSan",
                columns: table => new
                {
                    ID_KhachSan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(maxLength: 200, nullable: false),
                    TenKhachSan = table.Column<string>(maxLength: 500, nullable: false),
                    GioiThieu = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_KhachSan", x => x.ID_KhachSan);
                });

            migrationBuilder.CreateTable(
                name: "NN_TienIchMoRong",
                columns: table => new
                {
                    Id_NgonNgu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CongTy = table.Column<int>(nullable: false),
                    ID_TienichMoRong = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(nullable: true),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_TienIchMoRong", x => x.Id_NgonNgu);
                });

            migrationBuilder.CreateTable(
                name: "SoNguoiToiDa",
                columns: table => new
                {
                    ID_SoNguoiToiDa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoNguoiToiDa", x => x.ID_SoNguoiToiDa);
                });

            migrationBuilder.CreateTable(
                name: "TienIch",
                columns: table => new
                {
                    ID_TienIch = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIch", x => x.ID_TienIch);
                });

            migrationBuilder.CreateTable(
                name: "TienIchMoRong_CongTy",
                columns: table => new
                {
                    ID_CongTy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TienIchMoRong = table.Column<int>(nullable: false),
                    TenTienich = table.Column<string>(maxLength: 500, nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIchMoRong_CongTy", x => x.ID_CongTy);
                });

            migrationBuilder.CreateTable(
                name: "View",
                columns: table => new
                {
                    ID_View = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_View", x => x.ID_View);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CauHinhKhachSan");

            migrationBuilder.DropTable(
                name: "CongTy");

            migrationBuilder.DropTable(
                name: "Giuong");

            migrationBuilder.DropTable(
                name: "KhachSan");

            migrationBuilder.DropTable(
                name: "LoaiPhong");

            migrationBuilder.DropTable(
                name: "NgonNgu");

            migrationBuilder.DropTable(
                name: "NgonNgu_KhachSan");

            migrationBuilder.DropTable(
                name: "NN_KhachSan");

            migrationBuilder.DropTable(
                name: "NN_TienIchMoRong");

            migrationBuilder.DropTable(
                name: "SoNguoiToiDa");

            migrationBuilder.DropTable(
                name: "TienIch");

            migrationBuilder.DropTable(
                name: "TienIchMoRong_CongTy");

            migrationBuilder.DropTable(
                name: "View");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfKnowledgeBases",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfReports",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    KnowledgeBaseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.KnowledgeBaseId, x.UserId });
                });
        }
    }
}
