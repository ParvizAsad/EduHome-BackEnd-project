using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var blogs = await _dbContext.Blogs.Where(x => x.IsDeleted == false).Take(3).ToListAsync();
            var blogsDetail = await _dbContext.BlogDetails.ToListAsync();
            var blogsCategory = await _dbContext.BlogCategories.ToListAsync();

            return View(new HomeViewModel
            {
                Blogs = blogs,
                BlogDetails = blogsDetail,
                BlogCategories = blogsCategory

            });
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
