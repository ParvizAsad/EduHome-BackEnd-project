using EduHome.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class TeacherDetail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public int ComunicationPoint { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public int DevlopemntPoint { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public int InnovationPoint { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public int DesingPoint { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public int TeamLiderPoint { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public int LanguagePoint { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string SkypeProfile { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string PhoneNumbers { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!"), DataType(DataType.EmailAddress, ErrorMessage = "Düzgün E-poçt ünvanı daxil etdiyinizdən əmin olun!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Faculty { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Hobies { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!"), MaxLength(150, ErrorMessage = "Max 150 simvol istifadə edilə bilər!")]
        public string AboutTeacher { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeaacherID { get; set; }
        public Teacher Teaacher { get; set; }
    }
}
