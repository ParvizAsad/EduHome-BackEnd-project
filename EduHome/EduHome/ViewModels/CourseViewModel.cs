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

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string AboutDescription { get; set; }

        public string ApplyDescription { get; set; }

        public string CertificaitonDescription { get; set; }

        public DateTime StartDay { get; set; }

        public string DurationTime { get; set; }

        public string LessonDurationTime { get; set; }

        public string SkillLevel { get; set; }

        public string Language { get; set; }

        public int studentCapacity { get; set; }

        public string Assestments { get; set; }

        public double Price { get; set; }

        //public List<Categories> Categories { get; set; }

    }
}
