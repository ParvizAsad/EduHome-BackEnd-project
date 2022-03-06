using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Speaker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<EventSpeaker> EventSpeaker { get; set; }

    }
}
