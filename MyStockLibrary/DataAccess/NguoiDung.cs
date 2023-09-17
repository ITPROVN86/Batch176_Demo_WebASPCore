using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyStockLibrary.DataAccess
{
    public partial class NguoiDung
    {
        [Required(ErrorMessage = "Yêu cầu nhập Tên đăng nhập đầy đủ")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu đầy đủ")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Yêu cầu chọn loại người dùng")]
        public int LoaiNguoiDung { get; set; }
        public int? MaNguoiDung { get; set; }
        public bool Status { get; set; }

    }
}
