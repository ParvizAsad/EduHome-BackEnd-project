using EduHome.Models;
using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public User User { get; set; }
        public string Token { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}