using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare("Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

    }
}
