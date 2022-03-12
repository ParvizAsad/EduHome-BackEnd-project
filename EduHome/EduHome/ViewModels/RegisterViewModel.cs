using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required,EmailAddress, DataType(DataType.EmailAddress)] 
        public string Email { get; set; }

        [Required, DataType(DataType.Password)] 
        public string PassWord { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(PassWord))]
        public string ConfirmPassWord { get; set; }


    }
}
