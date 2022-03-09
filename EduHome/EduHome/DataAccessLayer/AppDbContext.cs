using EduHome.Models;
using EduHome.Models;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccessLayer
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Bios> Bios { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategories> BlogCategories { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }
        public DbSet<CourseCategories> CourseCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategories> EventCategories { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<TeacherCategory> TeacherCategorys { get; set; }
        public DbSet<Testimontial> Testimontials { get; set; }


    }
    
}
