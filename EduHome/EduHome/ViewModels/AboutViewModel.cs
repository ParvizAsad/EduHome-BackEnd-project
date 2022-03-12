using EduHome.Models;
using System.Collections.Generic;

namespace EduHome.ViewModels
{
    public class AboutViewModel
    {
        public List<Teacher> Teachers { get; set; }
        public List<TeacherDetail> TeacherDetails { get; set; }
        public List<TeacherCategory> TeacherCategories { get; set; }

    }
}
