﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_Backend.Models
{
    public class Slider
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Path { get; set; }

        [NotMapped]
        [Required]
        public IFormFile[] Photos { get; set; }
    }
}
