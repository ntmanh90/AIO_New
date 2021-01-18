using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIO.BackendServer.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "KnowledgeBaseSequence");

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EntityName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EntityId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(maxLength: 200, nullable: false),
                    FileType = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<long>(nullable: false),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaiDatBanPhongs",
                columns: table => new
                {
                    ID_CaiDatBanPhong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    GiaBan = table.Column<float>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    NgayCaiDat = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaiDatBanPhongs", x => x.ID_CaiDatBanPhong);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    SeoAlias = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 500, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    NumberOfTickets = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhKhachSan", x => x.ID);
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
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    KnowledgeBaseId = table.Column<int>(nullable: false),
                    OwnerUserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CongTy",
                columns: table => new
                {
                    ID_CongTy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTy = table.Column<string>(maxLength: 200, nullable: false),
                    DiaChiCongTy = table.Column<string>(maxLength: 200, nullable: false),
                    MaCongTy = table.Column<string>(maxLength: 50, nullable: false),
                    EmailCongTy = table.Column<string>(maxLength: 200, nullable: false),
                    AnhDaiDien = table.Column<string>(maxLength: 200, nullable: false),
                    NguoiDaiDien = table.Column<string>(maxLength: 200, nullable: false),
                    Hotline = table.Column<string>(maxLength: 200, nullable: false),
                    DienThoaiBan = table.Column<string>(maxLength: 200, nullable: false),
                    SoDiDong = table.Column<string>(maxLength: 200, nullable: false),
                    Note = table.Column<string>(maxLength: 2000, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTy", x => x.ID_CongTy);
                });

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
                    Index = table.Column<int>(nullable: false),
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
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID_HoaDon = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "HuongNhin",
                columns: table => new
                {
                    ID_HuongNhin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(maxLength: 500, nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuongNhin", x => x.ID_HuongNhin);
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
                    Hotline = table.Column<string>(maxLength: 200, nullable: false),
                    SoDiDong = table.Column<string>(maxLength: 50, nullable: false),
                    SoMayBan = table.Column<string>(maxLength: 200, nullable: false),
                    SoFax = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    DiaChiKhachSan = table.Column<string>(maxLength: 200, nullable: false),
                    Website = table.Column<string>(maxLength: 200, nullable: false),
                    Facebook = table.Column<string>(maxLength: 200, nullable: false),
                    Twitter = table.Column<string>(maxLength: 2000, nullable: false),
                    Youtube = table.Column<string>(maxLength: 2000, nullable: false),
                    Instagram = table.Column<string>(maxLength: 2000, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: false),
                    GioiThieu = table.Column<string>(maxLength: 200, nullable: false),
                    ViTri = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachSan", x => x.ID_KhachSan);
                });

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
                    Index = table.Column<int>(nullable: false),
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
                name: "KnowledgeBases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    SeoAlias = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Environment = table.Column<string>(maxLength: 500, nullable: false),
                    Problem = table.Column<string>(maxLength: 500, nullable: false),
                    StepToReproduce = table.Column<string>(nullable: false),
                    ErrorMessage = table.Column<string>(maxLength: 500, nullable: false),
                    Workaround = table.Column<string>(maxLength: 500, nullable: false),
                    Note = table.Column<string>(nullable: false),
                    OwnerUserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Labels = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    NumberOfComments = table.Column<int>(nullable: true),
                    NumberOfVotes = table.Column<int>(nullable: true),
                    NumberOfReports = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabelInKnowledgeBases",
                columns: table => new
                {
                    KnowledgeBaseId = table.Column<int>(nullable: false),
                    LabelId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
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
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiGiuong",
                columns: table => new
                {
                    ID_LoaiGiuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGiuong", x => x.ID_LoaiGiuong);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    ID_LoaiPhong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiPhong = table.Column<string>(nullable: false),
                    ID_KhachSan = table.Column<int>(nullable: false),
                    ID_HuongNhin = table.Column<int>(nullable: false),
                    NguoiLon = table.Column<int>(nullable: false),
                    TreEm = table.Column<int>(nullable: false),
                    TenLoaiPhong = table.Column<string>(nullable: false),
                    AnhDaiDien = table.Column<string>(nullable: false),
                    KichThuoc = table.Column<string>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.ID_LoaiPhong);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong_Gallery ",
                columns: table => new
                {
                    ID_Gallery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    Url_Gallery = table.Column<string>(maxLength: 500, nullable: false),
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
                name: "NgonNgu",
                columns: table => new
                {
                    ID_NgonNgu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyHieu = table.Column<string>(maxLength: 10, nullable: false),
                    TieuDe = table.Column<string>(maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    Delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgonNgu", x => x.ID_NgonNgu);
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

            migrationBuilder.CreateTable(
                name: "NN_HuongNhin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_HuongNhin = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_HuongNhin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NN_KhachSan",
                columns: table => new
                {
                    ID_KhachSan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NgonNgu = table.Column<int>(nullable: false),
                    TenKhachSan = table.Column<string>(maxLength: 500, nullable: false),
                    GioiThieu = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_KhachSan", x => x.ID_KhachSan);
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

            migrationBuilder.CreateTable(
                name: "NN_LoaiGiuong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_LoaiGiuong = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_LoaiGiuong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NN_LoaiPhong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_LoaiPhong = table.Column<int>(nullable: false),
                    TenLoaiPhongTheoNgonNgu = table.Column<string>(maxLength: 500, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "NN_SoNguoiToiDa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_NguoiToiDa = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_SoNguoiToiDa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NN_TienIch",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_TienIch = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_TienIch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NN_TienIchMoRong",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NgonNgu = table.Column<int>(nullable: false),
                    ID_CongTy = table.Column<int>(nullable: false),
                    ID_TienichMoRong = table.Column<int>(nullable: false),
                    NoiDungHienThi = table.Column<string>(maxLength: 500, nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NN_TienIchMoRong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    FunctionId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnowledgeBaseId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    ReportUserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    IsProcessed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoNguoiToiDa",
                columns: table => new
                {
                    ID_SoNguoiToiDa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(maxLength: 500, nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
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
                    TieuDe = table.Column<string>(maxLength: 500, nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
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
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    ModifyBy = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIchMoRong_CongTy", x => x.ID_CongTy);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "CaiDatBanPhongs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CauHinhKhachSan");

            migrationBuilder.DropTable(
                name: "CommandInFunctions");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CongTy");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "HuongNhin");

            migrationBuilder.DropTable(
                name: "KhachSan");

            migrationBuilder.DropTable(
                name: "KhuyenMaiDatPhong");

            migrationBuilder.DropTable(
                name: "KnowledgeBases");

            migrationBuilder.DropTable(
                name: "LabelInKnowledgeBases");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "LoaiGiuong");

            migrationBuilder.DropTable(
                name: "LoaiPhong");

            migrationBuilder.DropTable(
                name: "LoaiPhong_Gallery ");

            migrationBuilder.DropTable(
                name: "LoaiPhong_KhuyenMaiDatPhong");

            migrationBuilder.DropTable(
                name: "LoaiPhong_LoaiGiuong ");

            migrationBuilder.DropTable(
                name: "LoaiPhong_TienIch ");

            migrationBuilder.DropTable(
                name: "NgonNgu");

            migrationBuilder.DropTable(
                name: "NN_DichVu");

            migrationBuilder.DropTable(
                name: "NN_HuongNhin");

            migrationBuilder.DropTable(
                name: "NN_KhachSan");

            migrationBuilder.DropTable(
                name: "NN_KhuyenMaiDatPhong");

            migrationBuilder.DropTable(
                name: "NN_LoaiGiuong");

            migrationBuilder.DropTable(
                name: "NN_LoaiPhong");

            migrationBuilder.DropTable(
                name: "NN_SoNguoiToiDa");

            migrationBuilder.DropTable(
                name: "NN_TienIch");

            migrationBuilder.DropTable(
                name: "NN_TienIchMoRong");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SoNguoiToiDa");

            migrationBuilder.DropTable(
                name: "TienIch");

            migrationBuilder.DropTable(
                name: "TienIchMoRong_CongTy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "KnowledgeBaseSequence");
        }
    }
}
