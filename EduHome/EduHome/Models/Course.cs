using EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla bilməz!")]
        public string ImagePath { get; set; }
        
        [NotMapped]
        public IFormFile Photo { get; set; }
        
        public bool IsDeleted { get; set; } = false;
        public CourseDetail CourseDetail { get; set; }
        public ICollection<CourseCategories> CourseCategories { get; set; }
        public ICollection<CourseUser> CourseUser { get; set; }


    }
}
