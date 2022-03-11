using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Bios
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Logo { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string FacebookUrl { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string VcontactUrl { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string TwitterUrl { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string PinterestUrl { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string HeaderQuestionText { get; set; }     
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string HeaderNumber1 { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string FooterNumber1 { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string FooterNumber2 { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string infoSite { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!"), DataType(DataType.EmailAddress)]
        public string infoEmail { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string SubscribeTitle { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string SubscribeSubTitle { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
