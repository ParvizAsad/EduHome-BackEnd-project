using EduHome.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
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
        [NotMapped]
        public IFormFile Photo { get; set; }
        public ICollection<TeacherCategory> TeacherCategory { get; set; }

    }
}
