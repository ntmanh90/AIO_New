using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class database_LoaiPhong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiPhong",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "DiaChiKhachSan",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Hotline",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "LogoKhachSan",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "SoDiDong",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "SoFax",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "SoMayBan",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "TenLoaiPhongTA",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "TenLoaiPhongTV",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "LoaiPhong");

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "NgonNgu",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "TrangThai",
                table: "LoaiPhong",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModifyBy",
                table: "LoaiPhong",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "ID_LoaiPhong",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AnhDaiDien",
                table: "LoaiPhong",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID_HuongNhin",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_KhachSan",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_SoNguoiToiDa",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KichThuoc",
                table: "LoaiPhong",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiPhong",
                table: "LoaiPhong",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "LoaiPhong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiPhong",
                table: "LoaiPhong",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifyBy",
                table: "LoaiGiuong",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiPhong",
                table: "LoaiPhong",
                column: "ID_LoaiPhong");

            migrationBuilder.CreateTable(
                name: "LoaiPhong_Gallery ",
                columns: table => new
                {
                    ID_Gallery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    TenHinhAnh = table.Column<string>(maxLength: 500, nullable: false),
                    Url_Thumb = table.Column<string>(maxLength: 500, nullable: false),
                    Url_Privew = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong_Gallery ", x => x.ID_Gallery);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong_LoaiGiuong ",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_LoaiGiuong = table.Column<int>(nullable: false),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong_LoaiGiuong ", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong_TienIch ",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_TienIch = table.Column<int>(nullable: false),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong_TienIch ", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NN_LoaiPhong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_LoaiPhong", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiPhong_Gallery ");

            migrationBuilder.DropTable(
                name: "LoaiPhong_LoaiGiuong ");

            migrationBuilder.DropTable(
                name: "LoaiPhong_TienIch ");

            migrationBuilder.DropTable(
                name: "NN_LoaiPhong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiPhong",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "ID_LoaiPhong",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "AnhDaiDien",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "ID_HuongNhin",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "ID_KhachSan",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "ID_SoNguoiToiDa",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "KichThuoc",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "MaLoaiPhong",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "TenLoaiPhong",
                table: "LoaiPhong");

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "NgonNgu",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "LoaiPhong",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "ModifyBy",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "LoaiPhong",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DiaChiKhachSan",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hotline",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "LoaiPhong",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "LoaiPhong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoKhachSan",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SoDiDong",
                table: "LoaiPhong",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SoFax",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SoMayBan",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiPhongTA",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiPhongTV",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "LoaiPhong",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "LoaiPhong",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifyBy",
                table: "LoaiGiuong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiPhong",
                table: "LoaiPhong",
                column: "ID");
        }
    }
}
