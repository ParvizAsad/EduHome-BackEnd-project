using EduHome.Areas.Admin.Data;
using EduHome.DataAccessLayer;
using EduHome.Models;
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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public TeacherController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var blogdetail = await _dbContext.BlogDetails.ToListAsync();
            ViewBag.BlogDetail = blogdetail;

            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Teachers.Count() / take);
            ViewBag.currentpage = page;
            var teachers = await _dbContext.Teachers.Where(x => x.IsDeleted == false).Skip((page - 1) * take).Take(take).ToListAsync();
            return View(teachers);
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
        public async Task<IActionResult> Create(Teacher teacher, int categoryId)
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

            var isExistBlog = await _dbContext.Teachers.AnyAsync(x => x.Name.ToLower() == teacher.Name.ToLower());

            if (isExistBlog)
            {
                ModelState.AddModelError("Name", "Bu Name-da teacher mövcuddur!");
                return View();
            }

            if (!teacher.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil olmalıdır");
                return View();
            }

            if (teacher.Photo.Length > 1024 * 1000)
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil 1Mb-dan az olmalıdır");
                return View();
            }

            var webRootPath = _environment.WebRootPath;
            var fileName = $"{Guid.NewGuid()}-{teacher.Photo.FileName}";
            var path = Path.Combine(webRootPath, "img/teacher", fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await teacher.Photo.CopyToAsync(fileStream);


            var teacherCategories = new List<TeacherCategory>();

            var teacherCategory = new TeacherCategory
            {
                TeacherID = teacher.Id,
                CategoriesID = categoryId
            };
            teacherCategories.Add(teacherCategory);

            teacher.TeacherCategory = teacherCategories;

            teacher.ImagePath = fileName;
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var teacher = await _dbContext.Teachers
                .Where(x => x.Id == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTeacher(int? id)
        {
            if (id == null)
                return NotFound();

            var teacher = await _dbContext.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();

            teacher.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;


            var teacherCategories = await _dbContext.TeacherCategorys.Where(x => x.TeacherID == id).ToListAsync();
            ViewBag.teacherCategories = teacherCategories;

            var teacherDetail = await _dbContext.TeacherDetails.Where(x => x.TeaacherID == id).ToListAsync();
            ViewBag.teacherDetail = teacherDetail;

            if (id == null)
                return NotFound();

            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Teacher teacher)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var teacherCategories = await _dbContext.TeacherCategorys.Where(x => x.TeacherID == id).ToListAsync();
            ViewBag.teacherCategories = teacherCategories;

            var teacherDetail = await _dbContext.TeacherDetails.Where(x => x.TeaacherID == id).ToListAsync();
            ViewBag.teacherDetail = teacherDetail;

            if (id == null)
                return NotFound();

            if (id != teacher.Id)
                return BadRequest();

            var existTeacher = await _dbContext.Teachers.FindAsync(id);
            if (existTeacher == null)
                return NotFound();

            if (teacher.Photo != null)
            {
                if (!teacher.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yuklediyiniz shekil olmalidir.");
                    return View(existTeacher);
                }

                if (!teacher.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "1 mb-dan az olmalidir.");
                    return View(existTeacher);
                }

                var path = Path.Combine(Constants.ImageFolderPath, existTeacher.ImagePath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await teacher.Photo.GenerateFile(Constants.ImageFolderPath);
                existTeacher.ImagePath = fileName;
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
