using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class nhomQuyen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CommandInFunctions");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "KnowledgeBases");

            migrationBuilder.DropTable(
                name: "LabelInKnowledgeBases");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID_CongTy",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_NhomQuyen",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaTaiKhoan",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TrangThai",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ChucNang",
                columns: table => new
                {
                    ID_ChucNang = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TenChucNang = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNang", x => x.ID_ChucNang);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyen",
                columns: table => new
                {
                    ID_NhomQuyen = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    MaNhomQuyen = table.Column<string>(maxLength: 50, nullable: false),
                    TenNhomQuyen = table.Column<string>(maxLength: 200, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyen", x => x.ID_NhomQuyen);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyen_Thuoc_KhachSan",
                columns: table => new
                {
                    ID_NhomQuyen_Thuoc_KhachSan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NhomQuyen = table.Column<int>(nullable: false),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyen_Thuoc_KhachSan", x => x.ID_NhomQuyen_Thuoc_KhachSan);
                });

            migrationBuilder.CreateTable(
                name: "NhomQuyenChucNang",
                columns: table => new
                {
                    ID_NhomQuyenChucNang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ChucNang = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false),
                    ID_NhomQuyen = table.Column<int>(nullable: false),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    ID_QuyenThaoTac = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomQuyenChucNang", x => x.ID_NhomQuyenChucNang);
                });

            migrationBuilder.CreateTable(
                name: "QuyenThaoTac",
                columns: table => new
                {
                    ID_QuyenThaoTac = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenThaoTac", x => x.ID_QuyenThaoTac);
                });

            migrationBuilder.CreateTable(
                name: "QuyenThaoTacCuaChucNang",
                columns: table => new
                {
                    ID_QuyenThaoTacCuaChucNang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_QuyenThaoTac = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ID_ChucNang = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenThaoTacCuaChucNang", x => x.ID_QuyenThaoTacCuaChucNang);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan_QL_KhachSan",
                columns: table => new
                {
                    ID_TaiKhoan_QL_KhachSan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TaiKhoan = table.Column<string>(nullable: false),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan_QL_KhachSan", x => x.ID_TaiKhoan_QL_KhachSan);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanChucNang",
                columns: table => new
                {
                    ID_NhomQuyenChucNang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ChucNang = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false),
                    ID_TaiKhoan = table.Column<int>(nullable: false),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    ID_QuyenThaoTac = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanChucNang", x => x.ID_NhomQuyenChucNang);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChucNang");

            migrationBuilder.DropTable(
                name: "NhomQuyen");

            migrationBuilder.DropTable(
                name: "NhomQuyen_Thuoc_KhachSan");

            migrationBuilder.DropTable(
                name: "NhomQuyenChucNang");

            migrationBuilder.DropTable(
                name: "QuyenThaoTac");

            migrationBuilder.DropTable(
                name: "QuyenThaoTacCuaChucNang");

            migrationBuilder.DropTable(
                name: "TaiKhoan_QL_KhachSan");

            migrationBuilder.DropTable(
                name: "TaiKhoanChucNang");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID_CongTy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID_NhomQuyen",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaTaiKhoan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    SeoAlias = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandInFunctions",
                columns: table => new
                {
                    CommandId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FunctionId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandInFunctions", x => new { x.CommandId, x.FunctionId });
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KnowledgeBaseId = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerUserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Icon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Labels = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfComments = table.Column<int>(type: "int", nullable: true),
                    NumberOfReports = table.Column<int>(type: "int", nullable: true),
                    NumberOfVotes = table.Column<int>(type: "int", nullable: true),
                    OwnerUserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeoAlias = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    StepToReproduce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Workaround = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabelInKnowledgeBases",
                columns: table => new
                {
                    LabelId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    KnowledgeBaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelInKnowledgeBases", x => new { x.LabelId, x.KnowledgeBaseId });
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FunctionId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CommandId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.RoleId, x.FunctionId, x.CommandId });
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false),
                    KnowledgeBaseId = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportUserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });
        }
    }
}
