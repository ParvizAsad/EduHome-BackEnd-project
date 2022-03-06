using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class About
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string Title { get; set; }
       
        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string SubTitle { get; set; }
       
        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string ImagePath { get; set; }
       
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }

    }
}
