using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var slider = await _dbContext.Sliders.ToListAsync();
            var testimontal = await _dbContext.Testimontials.ToListAsync();
            var categories = await _dbContext.Categories.ToListAsync();
            var speaker = await _dbContext.Speakers.Where(x => x.IsDeleted == false).ToListAsync();


            var events = await _dbContext.Events.Where(x => x.IsDeleted == false).Take(4).ToListAsync();
            var eventDetail = await _dbContext.EventDetails.ToListAsync();
            var eventCategories = await _dbContext.EventCategories.ToListAsync();
            var eventSpeaker = await _dbContext.EventSpeakers.ToListAsync();

            var blog = await _dbContext.Blogs.Where(x => x.IsDeleted == false).ToListAsync();
            var blogDetail = await _dbContext.BlogDetails.ToListAsync();
            var blogCategory = await _dbContext.BlogCategories.ToListAsync();

            var course = await _dbContext.Courses.Where(x=>x.IsDeleted==false).Take(3).ToListAsync();
            var courseDetail = await _dbContext.CourseDetails.ToListAsync();
            var courseCategory = await _dbContext.CourseCategories.ToListAsync();

            var teachers = await _dbContext.Teachers.Where(x => x.IsDeleted == false).ToListAsync();
            var teacherDetails = await _dbContext.TeacherDetails.ToListAsync();
            var teacherCategory = await _dbContext.TeacherCategorys.ToListAsync();

            var home = await _dbContext.Homes.SingleOrDefaultAsync();
            var about = await _dbContext.Abouts.SingleOrDefaultAsync();

            return View(new HomeViewModel
            {
                Homes = home,
                Sliders = slider,
                Abouts=about,
                Testimontials=testimontal,
                Categories = categories,
                TeacherDetails = teacherDetails,
                Teachers = teachers,
                TeacherCategories = teacherCategory,
                CourseCategories=courseCategory,
                CourseDetail = courseDetail,
                Courses = course,
                BlogCategories = blogCategory,
                BlogDetails = blogDetail,
                Blogs=blog,
                EventCategories=eventCategories,
                EventDetails=eventDetail,
                Events = events,
                EventSpeakers=eventSpeaker,
                Speakers=speaker
            });
        }
    }
}
