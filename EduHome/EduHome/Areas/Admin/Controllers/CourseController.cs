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
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _environment;

        public CourseController(AppDbContext dbContext, IWebHostEnvironment environment, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Courses.Count() / take);
            ViewBag.currentpage = page;
            var courses = await _dbContext.Courses.Where(x => x.IsDeleted == false).Skip((page - 1) * take).Take(take).ToListAsync();
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
                ModelState.AddModelError("", "Bu name-də kurs mövcuddur!");
                return View();
            }

            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil olmalıdır");
                return View();
            }

            if (!course.Photo.IsAllowedSize(10))
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil 1Mb-dan az olmalıdır");
                return View();
            }

            var webRootPath = _environment.WebRootPath;
            var fileName = $"{Guid.NewGuid()}-{course.Photo.FileName}";
            var path = Path.Combine(webRootPath, "img/course", fileName);

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

            var userList = await _userManager.Users.Where(x => x.IsSubscribe == true).ToListAsync();

            foreach (var user in userList)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("codep320@gmail.com", "EduHome");
                msg.To.Add(user.Email);
                string body = string.Empty;
                using (StreamReader reader = new StreamReader("wwwroot/template/verifyemail.html"))
                {
                    body = reader.ReadToEnd();
                }
                msg.Body = body.Replace("{{link}}", link);
                body = body.Replace("{{name}}", $"Welcome, {user.UserName.ToUpper()}");
                msg.Subject = "VerifyEmail";
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("codep320@gmail.com", "codeacademyp320");
                smtp.Send(msg);
                TempData["confirm"] = true;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var category = await _dbContext.Courses
                .Where(x => x.Id == id && x.IsDeleted == false)
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
        public async Task<IActionResult> DeleteCourse(int? id)
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

        public async Task<IActionResult> Update(int? id)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;


            var courseCategories = await _dbContext.CourseCategories.Where(x => x.CourseID == id).ToListAsync();
            ViewBag.courseCategories = courseCategories;

            var courseDetail = await _dbContext.CourseDetails.Where(x => x.CourseID == id).ToListAsync();
            ViewBag.courseDetail = courseDetail;

            if (id == null)
                return NotFound();

            var course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var courseCategories = await _dbContext.CourseCategories.Where(x => x.CourseID == id).ToListAsync();
            ViewBag.courseCategories = courseCategories;

            var courseDetail = await _dbContext.CourseDetails.Where(x => x.CourseID == id).ToListAsync();
            ViewBag.courseDetail = courseDetail;

            if (id == null)
                return NotFound();

            if (id != course.Id)
                return BadRequest();

            var existCourse = await _dbContext.Courses.FindAsync(id);
            if (existCourse == null)
                return NotFound();

            if (course.Photo != null)
            {
                if (!course.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yuklediyiniz shekil olmalidir.");
                    return View(existCourse);
                }

                if (!course.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "1 mb-dan az olmalidir.");
                    return View(existCourse);
                }

                var path = Path.Combine(Constants.ImageFolderPath, existCourse.ImagePath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await course.Photo.GenerateFile(Constants.ImageFolderPath);
                existCourse.ImagePath = fileName;
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest();
            }

            await _userManager.ConfirmEmailAsync(user, token);
            await _signInManager.SignInAsync(user, true);
            TempData["confirmed"] = true;

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
