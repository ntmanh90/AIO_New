using AIO.BackendServer.Constants;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using AIO.BackendServer.Helpers;
using AIO.ViewModels.Systems;
using AIO.ViewModels.Systems.ChucNang;
using AIO.ViewModels.Systems.NhomQuyen;
using AIO.ViewModels.Systems.QuyenThaoTac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Controllers
{
    public class NhomQuyenController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly string tieuDe = "nhóm quyền";
        private InfoUser infoUser = new InfoUser();

        public NhomQuyenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("them")]
        [ApiValidationFilter]
        // [ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] NhomQuyenRequest request)
        {
            var max_id = _context.NhomQuyens.Any() ? _context.NhomQuyens.OrderByDescending(a => a.ID_NhomQuyen).FirstOrDefaultAsync().Result.ID_NhomQuyen : 0;
            // thêm thông tin loại phòng
            var nhomQuyen = new NhomQuyen()
            {
                MaNhomQuyen = infoUser.KyHieuKhachSan.Trim() + "-NQ-" + max_id + 1,
                TenNhomQuyen = request.TenNhomQuyen,
                ID_KhachSan = infoUser.ID_KhachSan,

                CreateBy = infoUser.TenDangNhap,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                ModifyBy = "",
                Delete = false
            };
            _context.NhomQuyens.Add(nhomQuyen);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(nhomQuyen);
            }
            else
            {
                return BadRequest(new ApiBadRequestResponse($"Tạo mới {tieuDe} thất bại."));
            }
        }

        [HttpGet("danh-sach")]
        //cliam
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.NhomQuyens.Where(a => a.ID_KhachSan == infoUser.ID_KhachSan && a.Delete == DeleteStatus.ChuaXoa).AsQueryable().ToListAsync();
            return Ok(result);
        }

        [Route("sua")]
        [HttpPut]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.VIEW)]
        [ApiValidationFilter]
        public async Task<IActionResult> Put([FromBody] NhomQuyenRequest request)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == request.ID_NhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return NotFound(new ApiNotFoundResponse($"{tieuDe} với id: {request.ID_NhomQuyen}  không tồn tại"));
            }

            nhomQuyen.TenNhomQuyen = request.TenNhomQuyen;

            _context.NhomQuyens.Update(nhomQuyen);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(nhomQuyen);
            }
            return BadRequest(new ApiBadRequestResponse("Cập nhật không thành công"));
        }

        [HttpDelete]
        [Route("xoa")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == id && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id} không tồn tại"));
            }
            nhomQuyen.Delete = true;
            _context.NhomQuyens.Update(nhomQuyen);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(new { kq = true });
            }
            return BadRequest(new ApiBadRequestResponse($"Xóa {tieuDe} không thành công"));
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObject = new NhomQuyenVM();
            var nhomQuyen = await _context.NhomQuyens.FirstOrDefaultAsync(a => a.ID_NhomQuyen == id && a.ID_KhachSan == infoUser.ID_KhachSan);
            if (nhomQuyen == null)
            {
                returnObject = new NhomQuyenVM
                {
                    ID_NhomQuyen = 0,
                    TenNhomQuyen = ""
                };

                return Ok(returnObject);
            }
            returnObject = new NhomQuyenVM
            {
                ID_NhomQuyen = nhomQuyen.ID_NhomQuyen,
                TenNhomQuyen = nhomQuyen.TenNhomQuyen
            };

            return Ok(returnObject);
        }

        [HttpGet("tai-khoan-thuoc-nhom-quyen")]
        public async Task<IActionResult> TaiKhoanThuocNhomQuyen(int id_nhomquyen)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == id_nhomquyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id_nhomquyen} không tồn tại"));
            }
            var query = from tk_ql in _context.TaiKhoan_QL_KhachSans
                        join tk in _context.Users
                        on tk_ql.ID_TaiKhoan equals tk.Id
                        where tk_ql.ID_KhachSan == infoUser.ID_KhachSan && tk.ID_NhomQuyen == id_nhomquyen
                        select new
                        {
                            TenDangNhap = tk.UserName,
                            TenDayDu = tk.FirstName + " " + tk.LastName
                        };

            var taiKhoanThuocNhomQuyens = await query.ToListAsync();
            return Ok(taiKhoanThuocNhomQuyens);
        }

        [HttpGet("tai-khoan-chua-phan-nhom-quyen")]
        public async Task<IActionResult> TaiKhoanChuaPhanNhomQuyen(int id_nhomquyen)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == id_nhomquyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id_nhomquyen} không tồn tại"));
            }
            var query = from tk_ql in _context.TaiKhoan_QL_KhachSans
                        join tk in _context.Users
                        on tk_ql.ID_TaiKhoan equals tk.Id
                        where tk_ql.ID_KhachSan == infoUser.ID_KhachSan && tk.ID_NhomQuyen == 0
                        select new
                        {
                            TenDangNhap = tk.UserName,
                            TenDayDu = tk.FirstName + " " + tk.LastName
                        };

            var taiKhoanChuaPhanNhomQuyens = await query.ToListAsync();
            return Ok(taiKhoanChuaPhanNhomQuyens);
        }

        [HttpPost]
        [Route("them-tai-khoan-vao-nhom-quyen")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> ThemTaiKhoanVaoNhomQuyen(ThemTaiKhoanVaoNhomQuyenRequest request)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == request.ID_NhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {request.ID_NhomQuyen} không tồn tại"));
            }
            var taiKhoanErrors = "";
            foreach (var id_taikhoan in request.ID_TaiKhoans)
            {
                var query_check_IdTaiKhoan = from tk_ql in _context.TaiKhoan_QL_KhachSans
                                             join tk in _context.Users on tk_ql.ID_TaiKhoan equals tk.Id
                                             where tk_ql.ID_KhachSan == infoUser.ID_KhachSan && tk.Id == id_taikhoan && tk.ID_NhomQuyen == 0
                                             select tk;
                var check_taikhoan = await query_check_IdTaiKhoan.FirstOrDefaultAsync();
                if (check_taikhoan != null)
                {
                    check_taikhoan.ID_NhomQuyen = request.ID_NhomQuyen;
                    _context.Users.Update(check_taikhoan);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var taikhoanError = await _context.Users.FirstOrDefaultAsync(a => a.Id == id_taikhoan);
                    if (taikhoanError != null)
                    {
                        taiKhoanErrors += taikhoanError.FirstName + " " + taikhoanError.LastName + ", ";
                    }
                }
            }
            if (taiKhoanErrors.Length > 0)
            {
                return BadRequest(new ApiBadRequestResponse($"Lỗi thêm các tài khoản sau vào nhóm quyền: " + taiKhoanErrors));
            }
            else
            {
                return Ok(new { kq = true });
            }
        }

        [HttpGet("chuc-nang-khong-thuoc-nhom-quyen")]
        public async Task<IActionResult> ChucNangKhongThuocNhomQuyen(int id_nhomquyen)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == id_nhomquyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id_nhomquyen} không tồn tại"));
            }
            var query = from nq_cn in _context.NhomQuyenChucNangs
                        join cn in _context.ChucNangs
                        on nq_cn.ID_ChucNang equals cn.ID_ChucNang
                        where nq_cn.ID_NhomQuyen == id_nhomquyen && nq_cn.ID_KhachSan == infoUser.ID_KhachSan
                        select cn;

            var all_chucNangKhongThuocNhomQuyens = await query.ToListAsync();
            if (all_chucNangKhongThuocNhomQuyens.Count == 0)
            {
                return BadRequest("Đã thêm tất cả chức năng cho nhóm chức năng này");
            }


            var chucNangKhongThuocNhomQuyens = new List<ChucNangVM>();
            foreach (var chucNang in all_chucNangKhongThuocNhomQuyens.Where(a => string.IsNullOrEmpty(a.ParentId)).ToList())
            {
                string nhomChucNang = "";
                if (await _context.ChucNangs.AnyAsync(a => a.ParentId == chucNang.ID_ChucNang) == false)
                {
                    if (string.IsNullOrEmpty(chucNang.ParentId))
                    {
                        nhomChucNang = chucNang.TenChucNang;
                        chucNangKhongThuocNhomQuyens.Add(new ChucNangVM
                        {
                            ID_ChucNang = chucNang.ID_ChucNang,
                            NhomChucNang = nhomChucNang,
                            TenChucNang = chucNang.TenChucNang
                        });
                    }
                    else
                    {
                        var chucNangChaCap1 = await _context.ChucNangs.FirstOrDefaultAsync(a => a.ID_ChucNang == chucNang.ParentId);
                        if (_context.ChucNangs.Any(a => a.ID_ChucNang == chucNangChaCap1.ParentId))
                        {
                            var chucNangChaCap2 = await _context.ChucNangs.FirstOrDefaultAsync(a => a.ID_ChucNang == chucNangChaCap1.ParentId);

                            nhomChucNang = chucNangChaCap2.TenChucNang + "/" + chucNangChaCap1.TenChucNang;
                            chucNangKhongThuocNhomQuyens.Add(new ChucNangVM
                            {
                                ID_ChucNang = chucNang.ID_ChucNang,
                                NhomChucNang = nhomChucNang,
                                TenChucNang = chucNang.TenChucNang
                            });
                        }
                        else
                        {
                            nhomChucNang = chucNangChaCap1.TenChucNang;
                            chucNangKhongThuocNhomQuyens.Add(new ChucNangVM
                            {
                                ID_ChucNang = chucNang.ID_ChucNang,
                                NhomChucNang = nhomChucNang,
                                TenChucNang = chucNang.TenChucNang
                            });
                        }
                    }

                }

            }

            return Ok(chucNangKhongThuocNhomQuyens);
        }


        [HttpPost]
        [Route("them-chuc-nang-vao-nhom-quyen")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> ThemChucNangVaoNhomQuyen(ThemChucNangVaoNhomQuyenRequest request)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == request.ID_NhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {request.ID_NhomQuyen} không tồn tại"));
            }
            var chucNangErrors = "";
            foreach (var id_chucnang in request.ID_ChucNangs)
            {
                var query_check_IdChucNang = from nq_cn in _context.NhomQuyenChucNangs
                                             join cn in _context.ChucNangs
                                             on nq_cn.ID_ChucNang equals cn.ID_ChucNang
                                             where nq_cn.ID_NhomQuyen == request.ID_NhomQuyen && nq_cn.ID_KhachSan == infoUser.ID_KhachSan && nq_cn.ID_ChucNang != id_chucnang
                                             select cn;

                var check_ChucNang = await query_check_IdChucNang.FirstOrDefaultAsync();
                if (check_ChucNang != null)
                {
                    NhomQuyenChucNang nhomQuyenChucNang = new NhomQuyenChucNang
                    {
                        ID_ChucNang = id_chucnang,
                        ID_KhachSan = infoUser.ID_KhachSan,
                        ID_NhomQuyen = request.ID_NhomQuyen,
                        ID_QuyenThaoTac = CommandCode.VIEW.ToString()
                    };
                    _context.NhomQuyenChucNangs.Add(nhomQuyenChucNang);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var chucNangError = await _context.ChucNangs.FirstOrDefaultAsync(a => a.ID_ChucNang == id_chucnang);
                    if (chucNangError != null)
                    {
                        chucNangErrors += chucNangError.TenChucNang + ", ";
                    }
                }
            }
            if (chucNangErrors.Length > 0)
            {
                return BadRequest(new ApiBadRequestResponse($"Lỗi thêm các chức năng sau vào nhóm quyền: " + chucNangErrors));
            }
            else
            {
                return Ok(new { kq = true });
            }
        }

        //Cập nhật quyền thao tác cho chức năng đã thêm vào nhóm quyền
        [HttpPost]
        [Route("cap-nhat-quyen-thao-tac-chuc-nang")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> CapNhatQuyenThaoTacChucNang(CapNhatQuyenThaoTacNhomQuyenRequest request)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == request.ID_NhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {request.ID_NhomQuyen} không tồn tại"));
            }
            var chucNang = await _context.NhomQuyenChucNangs.FirstOrDefaultAsync(a => a.ID_NhomQuyen == nhomQuyen.ID_NhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan && a.ID_ChucNang == request.ID_ChucNang);
            //check nhóm quyền có chức năng đã chọn không
            if (chucNang == null)
            {
                return BadRequest(new ApiBadRequestResponse($"Lỗi! không có quyền thao tác chức năng này"));
            }
            //Kiểm tra xem chức năng có quyền thao tác đã chọn không
            var quyenThaoTac = await _context.QuyenThaoTacCuaChucNangs.FirstOrDefaultAsync(a => a.ID_ChucNang == request.ID_ChucNang && a.ID_QuyenThaoTac == request.ID_QuyenThaoTac);
            if (quyenThaoTac == null)
            {
                return BadRequest(new ApiBadRequestResponse($"Lỗi! Chức năng không có quyền thao tác này."));
            }
            //Cập nhật trạng thái quyền thao tác chức năng


            if (request.LuaChon)
            {
                var nhomQuyenChucNang = await _context.NhomQuyenChucNangs.FirstOrDefaultAsync(a => a.ID_NhomQuyen == nhomQuyen.ID_NhomQuyen &&
                    a.ID_ChucNang == chucNang.ID_ChucNang && a.ID_QuyenThaoTac == quyenThaoTac.ID_QuyenThaoTac);
                if (nhomQuyenChucNang == null)
                {
                    _context.NhomQuyenChucNangs.Add(new NhomQuyenChucNang
                    {
                        ID_ChucNang = request.ID_ChucNang,
                        ID_NhomQuyen = request.ID_NhomQuyen,
                        ID_KhachSan = infoUser.ID_KhachSan,
                        ID_QuyenThaoTac = request.ID_QuyenThaoTac
                    });
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            else
            {
                var nhomQuyenChucNang = await _context.NhomQuyenChucNangs.FirstOrDefaultAsync(a => a.ID_NhomQuyen == nhomQuyen.ID_NhomQuyen &&
                        a.ID_ChucNang == chucNang.ID_ChucNang && a.ID_QuyenThaoTac == quyenThaoTac.ID_QuyenThaoTac);
                if (nhomQuyenChucNang != null)
                {
                    _context.NhomQuyenChucNangs.Remove(nhomQuyenChucNang);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
        }

        //Lấy danh sách chức năng bao gồm quyền thao tác đã thêm vào nhóm quyền

        [HttpGet]
        [Route("danh-sach-chuc-nang-theo-nhom")]
        //[ClaimRequirement(FunctionCode.DANHMUC_LOAI_GIUONG, CommandCode.DELETE)]
        public async Task<IActionResult> DanhSachChucNangTheoNhomQuyen(int id_nhomQuyen)
        {
            var nhomQuyen = _context.NhomQuyens.Where(a => a.ID_NhomQuyen == id_nhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan).FirstOrDefault();
            if (nhomQuyen == null)
            {
                return BadRequest(new ApiBadRequestResponse($"{tieuDe} với id: {id_nhomQuyen} không tồn tại"));
            }
            List<DanhSachChucNangTheoNhomQuyenVM> danhSachChucNangTheoNhomQuyenVMs = new List<DanhSachChucNangTheoNhomQuyenVM>();
            var chucNangThuocNhomQuyens = await _context.NhomQuyenChucNangs.Where(a => a.ID_NhomQuyen == nhomQuyen.ID_NhomQuyen && a.ID_KhachSan == infoUser.ID_KhachSan).ToListAsync();
            foreach(var chucNangThuocNhomQuyen in chucNangThuocNhomQuyens)
            {
                DanhSachChucNangTheoNhomQuyenVM itemChucNangNhomQuyen = new DanhSachChucNangTheoNhomQuyenVM
                {
                    ID_ChucNang = chucNangThuocNhomQuyen.ID_ChucNang,
                    ID_NhomQuyen = nhomQuyen.ID_NhomQuyen,
                    TenChucNang =  _context.ChucNangs.FirstOrDefault(a => a.ID_ChucNang == chucNangThuocNhomQuyen.ID_ChucNang).TenChucNang,
                };
                List<QuyenThaoTacVM> quyenThaoTacVMs = new List<QuyenThaoTacVM>();

                foreach (var quyenThaoTac in _context.QuyenThaoTacCuaChucNangs.Where(a=>a.ID_ChucNang == chucNangThuocNhomQuyen.ID_ChucNang).ToList())
                {
                    quyenThaoTacVMs.Add(new QuyenThaoTacVM
                    {
                        ID_QuyenThaoTac = quyenThaoTac.ID_QuyenThaoTac,
                        LuaChon = _context.NhomQuyenChucNangs.Any(a=>a.ID_QuyenThaoTac == quyenThaoTac.ID_QuyenThaoTac && 
                        a.ID_NhomQuyen == nhomQuyen.ID_NhomQuyen && a.ID_ChucNang == chucNangThuocNhomQuyen.ID_ChucNang)
                    });
                }
                itemChucNangNhomQuyen.QuyenThaoTacVMs = quyenThaoTacVMs;
                danhSachChucNangTheoNhomQuyenVMs.Add(itemChucNangNhomQuyen);
            }

            return Ok(danhSachChucNangTheoNhomQuyenVMs);

        }
    }
}