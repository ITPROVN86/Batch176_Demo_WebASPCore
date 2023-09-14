using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyStockLibrary.DataAccess
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name ="Mã khách hàng")]
        public int MaKhachHang { get; set; }

        [Display(Name ="Tên khách hàng")]
        [Required(ErrorMessage ="Yêu cầu nhập tên khách hàng đầy đủ")]
        public string TenKhachHang { get; set; }

        [Display(Name ="Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập Địa chỉ đầy đủ")]
        public string DiaChi { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập Điện thoại đầy đủ")]
        public string DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
