using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_Backend.Models
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
        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
