using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Testimontial
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Position { get; set; }

    }
}
