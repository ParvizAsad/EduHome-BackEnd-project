using EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.ViewModels
{
    public class CourseViewModel
    {
        public Course Courses { get; set; }
        public List<CourseDetail> CourseDetails { get; set; }
        public List<CourseCategories> CourseCategories { get; set; }
        public List<Categories> Categories { get; set; }


    }
}
