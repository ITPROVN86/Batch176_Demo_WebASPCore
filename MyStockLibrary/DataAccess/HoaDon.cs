using System;
using System.Collections.Generic;

namespace MyStockLibrary.DataAccess
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaHoaDon { get; set; }
        public int MaNhanVien { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime NgayBan { get; set; }
        public decimal TongTien { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
