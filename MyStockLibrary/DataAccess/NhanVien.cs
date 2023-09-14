using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyStockLibrary.DataAccess
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int MaNhanVien { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Tên nhân viên đầy đủ")]
        public string TenNhanVien { get; set; }
        [Required(ErrorMessage = "Yêu cầu chọn Giới tính")]
        public bool GioiTinh { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Địa chỉ đầy đủ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại đầy đủ")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10,}$",ErrorMessage ="Số điện thoại phải hợp lệ")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Ngày sinh đầy đủ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }


        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
