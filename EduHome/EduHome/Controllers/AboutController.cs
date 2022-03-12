using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var teachers = await _dbContext.Teachers.Where(x => x.IsDeleted == false).ToListAsync();
            var teacherDetails = await _dbContext.TeacherDetails.ToListAsync();
            var teacherCategory = await _dbContext.TeacherCategorys.ToListAsync();

            return View(new AboutViewModel
            {
                TeacherDetails = teacherDetails,
                Teachers = teachers,
                TeacherCategories = teacherCategory,
            });
        }

    }
}
