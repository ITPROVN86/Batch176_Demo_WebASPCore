using System;
using System.Collections.Generic;

namespace MyStockLibrary.DataAccess
{
    public partial class ChiTietHoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaHangHoa { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? GiamGia { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual HangHoa MaHangHoaNavigation { get; set; }
        public virtual HoaDon MaHoaDonNavigation { get; set; }
    }
}
