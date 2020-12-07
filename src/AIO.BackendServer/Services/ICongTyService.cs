using AIO.ViewModels.CongTy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services.CongTySer
{
    public interface ICongTyService
    {
        Task<int> ThemCongTy(CongTyRequest model);

        Task<List<CongTyVM>> DanhSachCongTy();

        Task<int> SuaCongTy(CongTyRequest model);

        Task<CongTyVM> ChiTietCongTy(int id);

        Task<int> XoaCongTy(int id);
    }
}