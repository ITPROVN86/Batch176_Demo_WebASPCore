using System.ComponentModel.DataAnnotations;

namespace MyCodeFirstApproach.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

    }
}
