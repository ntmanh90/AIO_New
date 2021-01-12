using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Helpers
{
    public class IdGenerator
    {
        public static string NextId_LoaiPhong(int _value)
        {
            int Min = 0xA0000;
            int Max = 0xFFFF9;
            _value = Min - 1;
            if (_value < Max)
            {
                _value++;
            }
            else
            {
                _value = Min;
            }
            return _value.ToString("X");
        }
        public static string NextId_DichVu(int _value)
        {
            int Min = 0xA0000;
            int Max = 0xFFFF9;
            _value = Min - 1;
            if (_value < Max)
            {
                _value++;
            }
            else
            {
                _value = Min;
            }
            return _value.ToString("X");
        }
    }
}
