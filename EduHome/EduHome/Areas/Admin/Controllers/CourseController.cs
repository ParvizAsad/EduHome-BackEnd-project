using EduHome.DataAccessLayer;
using EduHome.Models;
using EduHome.ViewModels;
using EduHome.Areas.Admin.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public CourseController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Courses.Count() / take);
            ViewBag.currentpage = page;
            var courses = await _dbContext.Courses.Where(x=>x.IsDeleted==false).Skip((page - 1) * take).Take(take).ToListAsync();
            return View(courses);
        }

        public IActionResult ExportFile()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course, int categoryId)
        {

            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            if (categoryId == 0)
            {
                ModelState.AddModelError("Categories", "Parent kateqoriyasi sechin.");
                return View();
            }

            var parentCategory = categories.FirstOrDefault(x => x.ID == categoryId);
            if (parentCategory == null)
                return BadRequest();

            var isExistBlog = await _dbContext.Courses.AnyAsync(x => x.Name.ToLower() == course.Name.ToLower());

            if (isExistBlog)
            {
                ModelState.AddModelError("Title", "Bu title-da blog mövcuddur!");
                return View();
            }

            if (!course.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil olmalıdır");
                return View();
            }

            if (course.Photo.Length > 1024 * 1000)
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil 1Mb-dan az olmalıdır");
                return View();
            }

            var webRootPath = _environment.WebRootPath;
            var fileName = $"{Guid.NewGuid()}-{course.Photo.FileName}";
            var path = Path.Combine(webRootPath, "img", fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await course.Photo.CopyToAsync(fileStream);

            var courseCategories = new List<CourseCategories>();

            var courseCategory = new CourseCategories
            {
                CourseID = course.Id,
                CategoriesID = categoryId
            };
            courseCategories.Add(courseCategory);

            course.CourseCategories = courseCategories;

            course.ImagePath = fileName;
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var category = await _dbContext.Courses
                .Where(x => x.Id == id && x.IsDeleted==false)
                .FirstOrDefaultAsync();
            if (category == null)
                return NotFound();

            return View(category);

            //if (id == null)
            //    return NotFound();

            //var course = await _dbContext.Courses
            //    .Where(x => x.Id == id && x.IsDeleted == false)
            //    .FirstOrDefaultAsync();
            //if (course == null)
            //    return NotFound();

            //return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            course.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }






    }
}
