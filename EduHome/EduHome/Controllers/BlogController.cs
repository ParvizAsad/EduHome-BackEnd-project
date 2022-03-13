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

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var blogs = await _dbContext.Blogs.Include(x => x.BlogDetail).FirstOrDefaultAsync(x => x.Id == id);
            var blogsdetail = await _dbContext.BlogDetails.Where(x => x.BlogID == id).ToListAsync();
            ViewBag.blogsdetail = blogsdetail;

            var categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Categories = categories;

            var blogPost = await _dbContext.Blogs.Where(x => x.IsDeleted == false).Take(3).ToListAsync();
            ViewBag.Blogs = blogPost;

            if (blogs == null)
                return NotFound();

            return View(blogs);
        }
    }
}
