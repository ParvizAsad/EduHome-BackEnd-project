using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Bios
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string FacebookUrl { get; set; }
        public string VcontactUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string Adress { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public int Number3 { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
