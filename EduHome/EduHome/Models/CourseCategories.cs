using System.Collections.Generic;

namespace EduHome.Models
{
    public class CourseCategories
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseID { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesID { get; set; }

    }
}
