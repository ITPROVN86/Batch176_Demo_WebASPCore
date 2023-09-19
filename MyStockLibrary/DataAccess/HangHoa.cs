using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStockLibrary.DataAccess
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaHangHoa { get; set; }

        [Required(ErrorMessage ="Yêu cầu nhập tên hàng hoá")]
        public string TenHangHoa { get; set; }

        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="Yêu cầu nhập kiểu số")]
        [Required(ErrorMessage = "Yêu cầu nhập số lượng hàng")]
        public int SoLuong { get; set; }
        /*  [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Yêu cầu nhập kiểu số")]
          [DisplayFormat(DataFormatString = "{0:N0}")]*/
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? DonGiaNhap { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? DonGiaBan { get; set; }
        public string? Anh { get; set; }
     
        public string? GhiChu { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
