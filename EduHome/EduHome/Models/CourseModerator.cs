namespace EduHome.Models
{
    public class CourseModerator
    {
        public int ID { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }

    }
}
