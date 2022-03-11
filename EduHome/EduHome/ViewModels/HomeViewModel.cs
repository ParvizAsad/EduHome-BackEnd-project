using EduHome.Models;
using System.Collections.Generic;

namespace EduHome.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Testimontial> Testimontials { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseDetail> CourseDetail { get; set; }
        public List<CourseCategories> CourseCategories { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherDetail> TeacherDetails { get; set; }
        public List<TeacherCategory> TeacherCategories { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<BlogCategories> BlogCategories { get; set; }
        public List<BlogDetail> BlogDetails { get; set; }
        public List<EventCategories> EventCategories { get; set; }
        public List<Event> Events { get; set; }
        public List<EventDetail> EventDetails { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Speaker> Speakers { get; set; }
        public Home Homes { get; set; }
        public About Abouts { get; set; }




    }
}
