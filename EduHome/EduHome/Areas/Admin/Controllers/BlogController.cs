using EduHome.Areas.Admin.Data;
using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _environment;

        public BlogController(AppDbContext dbContext, IWebHostEnvironment environment, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var blogdetail = await _dbContext.BlogDetails.ToListAsync();
            ViewBag.BlogDetail = blogdetail;

            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Blogs.Count() / take);
            ViewBag.currentpage = page;
            var blogs = await _dbContext.Blogs.Where(x => x.IsDeleted == false).Skip((page - 1) * take).Take(take).ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog, int categoryId)
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

            var isExistBlog = await _dbContext.Blogs.AnyAsync(x => x.Title.ToLower() == blog.Title.ToLower());

            if (isExistBlog)
            {
                ModelState.AddModelError("Title", "Bu title-da blog mövcuddur!");
                return View();
            }

            if (!blog.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil olmalıdır");
                return View();
            }

            if (blog.Photo.Length > 1024 * 1000)
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil 1Mb-dan az olmalıdır");
                return View();
            }

            var webRootPath = _environment.WebRootPath;
            var fileName = $"{Guid.NewGuid()}-{blog.Photo.FileName}";
            var path = Path.Combine(webRootPath, "img/blog", fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await blog.Photo.CopyToAsync(fileStream);

            var blogCategories = new List<BlogCategories>();

            var blogCategory = new BlogCategories
            {
                BlogID = blog.Id,
                CategoriesID = categoryId
            };
            blogCategories.Add(blogCategory);

            blog.BlogCategories = blogCategories;

            blog.ImagePath = fileName;
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();

            var userList = await _userManager.Users.Where(x => x.IsSubscribe==true).ToListAsync();

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

            var blog = await _dbContext.Blogs
                .Where(x => x.Id == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = await _dbContext.Blogs.FindAsync(id);
            if (blog == null)
                return NotFound();

            blog.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var blogCategories = await _dbContext.BlogCategories.Where(x => x.BlogID == id).ToListAsync();
            ViewBag.blogCategories = blogCategories;

            var blogDetail = await _dbContext.BlogDetails.Where(x => x.BlogID == id).ToListAsync();
            ViewBag.blogDetail = blogDetail;

            if (id == null)
                return NotFound();

            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var blogCategories = await _dbContext.BlogCategories.Where(x => x.BlogID == id).ToListAsync();
            ViewBag.blogCategories = blogCategories;

            var blogDetail = await _dbContext.BlogDetails.Where(x => x.BlogID == id).ToListAsync();
            ViewBag.blogDetail = blogDetail;

            if (id == null)
                return NotFound();

            if (id != blog.Id)
                return BadRequest();

            var existBlog = await _dbContext.Blogs.FindAsync(id);
            if (existBlog == null)
                return NotFound();

            if (blog.Photo != null)
            {
                if (!blog.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yuklediyiniz shekil olmalidir.");
                    return View(existBlog);
                }

                if (!blog.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "1 mb-dan az olmalidir.");
                    return View(existBlog);
                }

                var path = Path.Combine(Constants.ImageFolderPath, existBlog.ImagePath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await blog.Photo.GenerateFile(Constants.ImageFolderPath);
                existBlog.ImagePath = fileName;
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
