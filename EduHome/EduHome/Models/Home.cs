using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Home
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string CourseIcon { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string CourseTitle { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string CourseBackgroundImage { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string NoticeTitles { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string NoticeVideoTitle { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string NoticeImage { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string YoutubeUrL { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string EventIcon { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string BlogIcon { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string BlogTitle { get; set; }


    }
}
