using EduHome.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class CourseDetail
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string AboutDescription { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string ApplyDescription { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string CertificaitonDescription { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public DateTime StartDay { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string DurationTime { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string LessonDurationTime { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string SkillLevel { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public int studentCapacity { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string Assestments { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
