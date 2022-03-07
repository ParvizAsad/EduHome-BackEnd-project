using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Categories
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CourseCategories> CourseCategories { get; set; }
        public ICollection<EventCategories> EventCategories { get; set; }
        public ICollection<TeacherCategory> TeacherCategory { get; set; }
        public ICollection<BlogCategories> BlogCategories { get; set; }

    }
}
