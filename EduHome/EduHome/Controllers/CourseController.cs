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

            var course = await _dbContext.Courses.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(c=> c.Id==id);

            //var coursedetail = await _dbContext.CourseDetails.Where(x => x.CourseID == id).ToListAsync();
            //ViewBag.CourseDetail = coursedetail;

            if (course == null)
                return NotFound();

            CourseViewModel courseDetailVM = new CourseViewModel()
            {
                Name = course.Name,
                AboutDescription = course.CourseDetail.AboutDescription,
                CertificaitonDescription = course.CourseDetail.CertificaitonDescription,
                 DurationTime= course.CourseDetail.DurationTime,
                 Language=course.CourseDetail.Language,
                 Assestments=course.CourseDetail.Assestments,
                 LessonDurationTime=course.CourseDetail.LessonDurationTime,
                 Price=course.CourseDetail.Price,
                 SkillLevel=course.CourseDetail.SkillLevel,
                 StartDay=course.CourseDetail.StartDay,
                 studentCapacity=course.CourseDetail.studentCapacity,
                 ApplyDescription=course.CourseDetail.ApplyDescription,
                 ImagePath=course.ImagePath,
                 Description=course.Description
                 
            };

            return View(courseDetailVM);

        }

    }
}
