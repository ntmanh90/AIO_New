using System.Collections.Generic;

namespace AIO.BackendServer.Constants
{
    public class HinhThucThanhToanConst
    {
        public static int LayThongTinThe = 1;
        public static int VnPay = 2;

        public static Dictionary<int, string> HinhThucThanhToans = new Dictionary<int, string>
        {
            {LayThongTinThe, "Lấy thông tin thẻ" },
            {VnPay,"VnPay" }
        };
    }
}