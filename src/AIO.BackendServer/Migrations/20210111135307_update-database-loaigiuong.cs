using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class updatedatabaseloaigiuong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiDungHienThi",
                table: "NN_LoaiPhong");

            migrationBuilder.DropColumn(
                name: "TenHinhAnh",
                table: "LoaiPhong_Gallery ");

            migrationBuilder.DropColumn(
                name: "Url_Privew",
                table: "LoaiPhong_Gallery ");

            migrationBuilder.DropColumn(
                name: "Url_Thumb",
                table: "LoaiPhong_Gallery ");

            migrationBuilder.DropColumn(
                name: "ID_SoNguoiToiDa",
                table: "LoaiPhong");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiPhongTheoNgonNgu",
                table: "NN_LoaiPhong",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url_Gallery",
                table: "LoaiPhong_Gallery ",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiPhong",
                table: "LoaiPhong",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ModifyBy",
                table: "LoaiPhong",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiPhong",
                table: "LoaiPhong",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "KichThuoc",
                table: "LoaiPhong",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "LoaiPhong",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "AnhDaiDien",
                table: "LoaiPhong",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "NguoiLon",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreEm",
                table: "LoaiPhong",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenLoaiPhongTheoNgonNgu",
                table: "NN_LoaiPhong");

            migrationBuilder.DropColumn(
                name: "Url_Gallery",
                table: "LoaiPhong_Gallery ");

            migrationBuilder.DropColumn(
                name: "NguoiLon",
                table: "LoaiPhong");

            migrationBuilder.DropColumn(
                name: "TreEm",
                table: "LoaiPhong");

            migrationBuilder.AddColumn<string>(
                name: "NoiDungHienThi",
                table: "NN_LoaiPhong",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenHinhAnh",
                table: "LoaiPhong_Gallery ",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url_Privew",
                table: "LoaiPhong_Gallery ",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url_Thumb",
                table: "LoaiPhong_Gallery ",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiPhong",
                table: "LoaiPhong",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ModifyBy",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiPhong",
                table: "LoaiPhong",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "KichThuoc",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "LoaiPhong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AnhDaiDien",
                table: "LoaiPhong",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ID_SoNguoiToiDa",
                table: "LoaiPhong",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
