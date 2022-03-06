using EduHome.Models;
using System.ComponentModel.DataAnnotations;

namespace EduHome_Backend.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!"), MaxLength(30, ErrorMessage ="Max 30 simvol istifadə edilə bilər!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string FacebookUrl { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string TwitterUrl { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string PinterestUrl { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string VkontaktUrl { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!"), MaxLength(20, ErrorMessage = "Max 20 simvol istifadə edilə bilər!")]
        public string Job { get; set; }
        public TeacherDetail TeacherDetail { get; set; }

        public bool IsDeleted { get; set; }
    }
}
