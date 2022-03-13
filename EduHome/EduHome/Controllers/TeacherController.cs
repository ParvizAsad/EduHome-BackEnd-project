using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TeacherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var teachers = await _dbContext.Teachers.Where(x => x.IsDeleted == false).ToListAsync();
            var teachersDetail = await _dbContext.TeacherDetails.ToListAsync();
            var teachersCategory = await _dbContext.TeacherCategorys.ToListAsync();

            return View(new HomeViewModel
            {
                Teachers = teachers,
                TeacherDetails = teachersDetail,
                TeacherCategories = teachersCategory

            });
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var teacher = await _dbContext.Teachers.Include(x => x.TeacherDetail).Include(c=>c.TeacherCategory.Where(x=> x.TeacherID==id)).FirstOrDefaultAsync(x => x.Id == id);
            var teacherdetail = await _dbContext.TeacherDetails.Where(x => x.TeaacherID == id).ToListAsync();
            var teacherCategories = await _dbContext.TeacherCategorys.Where(x => x.TeacherID == id).SingleOrDefaultAsync();

            var categories = await _dbContext.Categories.Where(x=> x.IsDeleted==false).ToListAsync();
            ViewBag.Categories = categories;

            foreach (var item in categories)
            {
                if (item.ID==teacherCategories.CategoriesID)
                {
                    ViewBag.TeacherCategory = item.Name;
                }
            }

            var blogs = await _dbContext.Blogs.Where(x => x.IsDeleted == false).Take(3).ToListAsync();
            ViewBag.Blogs = blogs;

            if (teacher == null)
                return NotFound();

            return View(teacher);
        }
    }
}
