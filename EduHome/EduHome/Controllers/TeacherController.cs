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

        public async Task<IActionResult> Detail(int id)
        {
            var teachers = await _dbContext.Teachers.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x=>x.Id==id);
            var teachersDetail = await _dbContext.TeacherDetails.ToListAsync();
            var teachersCategory = await _dbContext.TeacherCategorys.ToListAsync();

            return View(new HomeViewModel
            {
                //Teachers = teachers,
                TeacherDetails = teachersDetail,
                TeacherCategories = teachersCategory

            });
        }
    }
}
