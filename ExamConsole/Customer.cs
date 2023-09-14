using System.ComponentModel.DataAnnotations;

namespace ExamConsole
{
    public class Customer
    {
       
        public int MaKhachHang { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Tên khách hàng")]
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
    }
}
