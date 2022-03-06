using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Home
    {
        public int ID { get; set; }

        public string CourseIcon { get; set; }

        public string CourseTitle { get; set; }

        public string CourseBackgroundImage { get; set; }
        [Required]
        public string NoticeTitles { get; set; }
        public string NoticeVideoTitle { get; set; }
        public string NoticeImage { get; set; }
        public string YoutubeUrL { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
        public string EventIcon { get; set; }

        public string EventTitle { get; set; }

        public string BlogIcon { get; set; }

        public string BlogTitle { get; set; }
        public string SubscribeTitle { get; set; }
        public string SubscribeSubTitle { get; set; }

    }
}
