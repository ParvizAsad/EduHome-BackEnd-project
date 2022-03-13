using EduHome.DataAccessLayer;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();
            var category = await _dbContext.Categories.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.ID == id);

            var teachers = await _dbContext.Teachers.Include(x=>x.TeacherCategory).Where(x=>x.IsDeleted==false).ToListAsync();
            var teacherCategories = await _dbContext.TeacherCategorys.Where(x=>x.CategoriesID==id).ToListAsync();

            var blogs = await _dbContext.Blogs.Where(x=>x.IsDeleted==false).Include(x=>x.BlogCategories).ToListAsync();
            var blogCategories = await _dbContext.BlogCategories.Where(x => x.CategoriesID == id).ToListAsync();

            var courses = await _dbContext.Courses.Where(x=>x.IsDeleted==false).ToListAsync();
            var courseCategories = await _dbContext.CourseCategories.Where(x => x.CategoriesID == id).ToListAsync();

            var events = await _dbContext.Events.Where(x=>x.IsDeleted==false).ToListAsync();
            var eventCategories = await _dbContext.EventCategories.Where(x => x.CategoryID == id).ToListAsync();

            List<Teacher> teacherList= new List<Teacher>();
            List<Blog> blogList= new List<Blog>();
            List<Event> eventList= new List<Event>();
            List<Course> courseList= new List<Course>();

            foreach (var teachercategory in teacherCategories)
            {
                foreach (var item in teachers)
                {
                    if (item.Id == teachercategory.TeacherID)
                    {
                        teacherList.Add(item);
                    }
                }
            }
            ViewBag.TeacherList = teacherList;


            foreach (var coursecategory in courseCategories)
            {
                foreach (var item in courses)
                {
                    if (item.Id == coursecategory.CourseID)
                    {
                        courseList.Add(item);
                    }
                }
            }
            ViewBag.CourseList = courseList;

            foreach (var blogcategory in blogCategories)
            {
                foreach (var item in blogs)
                {
                    if (item.Id == blogcategory.BlogID)
                    {
                        blogList.Add(item);
                    }
                }
            }
            ViewBag.BlogList = blogList;

            foreach (var eventcategory in eventCategories)
            {
                foreach (var item in events)
                {
                    if (item.ID == eventcategory.EventID)
                    {
                        eventList.Add(item);
                    }
                }
            }
            ViewBag.EventList = eventList;


            return View();
        }
    }
}
