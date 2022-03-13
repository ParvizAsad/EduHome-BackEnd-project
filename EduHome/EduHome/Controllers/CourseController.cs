using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CourseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var course = await _dbContext.Courses.Where(x => x.IsDeleted == false).ToListAsync();
            var courseDetail = await _dbContext.CourseDetails.ToListAsync();
            var courseCategory = await _dbContext.CourseCategories.ToListAsync();

            return View(new HomeViewModel
            {
                Courses = course,   
                CourseDetail = courseDetail,
                CourseCategories= courseCategory

            });
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

             var course = await _dbContext.Courses.Include(x=>x.CourseDetail).FirstOrDefaultAsync(x=>x.Id==id);
            var coursedetail = await _dbContext.CourseDetails.Where(x => x.CourseID == id).ToListAsync();
            ViewBag.coursedetail = coursedetail;

            var categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Categories = categories;

            var blogs = await _dbContext.Blogs.Where(x=> x.IsDeleted==false).Take(3).ToListAsync();
            ViewBag.Blogs = blogs;

            if (course == null)
                return NotFound();

            return View(course);
        }

        public async Task<IActionResult> Search(string searchedCourse)
        {
            if (string.IsNullOrEmpty(searchedCourse))
            {
                return NoContent();
            }

            var course = await _dbContext.Courses.Where(x => x.Name.ToLower().Contains(searchedCourse
                .ToLower())).ToListAsync();

            return PartialView("_CourseSearchPartial", course);
        }


    }
}
