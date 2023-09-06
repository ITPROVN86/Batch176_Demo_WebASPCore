using System;
using System.Collections.Generic;

namespace MyStockLibrary.DataAccess
{
    public partial class NguoiDung
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int LoaiNguoiDung { get; set; }
        public int? MaNguoiDung { get; set; }
    }
}
