using EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; } 
        [Required(ErrorMessage ="Boş saxlanıla Bilməz!")]
        public string Writer { get; set; }

        [Required(ErrorMessage ="Boş saxlanıla Bilməz!"), MaxLength(40, ErrorMessage = "Max 40 simvol istifadə edilə bilər!")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Boş saxlanıla Bilməz!")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage ="Boş saxlanıla Bilməz!")]
        public DateTime Date { get; set; }

        public int CommentCount { get; set; }
        public BlogDetail BlogDetail { get; set; }

        [NotMapped]
        public IFormFile  Photo { get; set; }

     
    }
}
