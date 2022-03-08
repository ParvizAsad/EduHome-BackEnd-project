using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Categories.Count() / take);
            ViewBag.currentpage = page;
            var categories = await _dbContext.Categories.Where(x=>x.IsDeleted==false).Skip((page - 1) * take).Take(take).ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> ExportFile()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var isExistCategory = await _dbContext.Categories.AnyAsync(x => x.Name.ToLower() == categories.Name.ToLower());

            if (isExistCategory)
            {
                ModelState.AddModelError("Name", "Bu adda kateqorya mövcuddur!");
                return View();
            }

            await _dbContext.Categories.AddAsync(categories);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            return View(category);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories
                .Where(x => x.ID == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            category.IsDeleted = true;
            await _dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }

        //public IActionResult Delete(int id)
        //{
        //    var isExist = _dbContext.Categories.FirstOrDefault(x => x.ID == id);
        //    if (isExist == null) return Json(new { status = 404 });
        //    _dbContext.Categories.Remove(isExist);
        //    _dbContext.SaveChanges();
        //    return Json(new { status = 200 });
        //}
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.ID == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Categories category)
        {
            if (id == null)
                return NotFound();

            if (id != category.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return View();

            var existCategory = await _dbContext.Categories.FindAsync(id);
            if (existCategory == null)
                return NotFound();

            var isExist = await _dbContext.Categories
                .AnyAsync(x => x.Name.ToLower().Trim() == category.Name.ToLower().Trim() && x.ID != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Eyni adda category movcuddur");
                return View();
            }

            existCategory.Name = category.Name;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
