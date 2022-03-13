using EduHome.Models;
using System.Collections.Generic;

namespace EduHome.ViewModels
{
    public class CategoryDetailViewModel
    {
        public List<Teacher> TeacherList { get; set; }
        public List<Blog> BlogList { get; set; }
        public List<Event> EventList { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
