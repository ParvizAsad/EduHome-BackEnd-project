using EduHome.Areas.Admin.Data;
using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]

    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _environment;

        public EventController(AppDbContext dbContext, IWebHostEnvironment environment, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Events.Count() / take);
            ViewBag.currentpage = page;
            var events = await _dbContext.Events.Where(x => x.IsDeleted == false).Skip((page - 1) * take).Take(take).ToListAsync();
            return View(events);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Categories = categories;

            var spiker = await _dbContext.Speakers.ToListAsync();
            ViewBag.Speakers = spiker;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events, int categoryId, int speakerId)
        {

            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var spiker = await _dbContext.Speakers.ToListAsync();
            ViewBag.Speakers = spiker;

            if (categoryId == 0)
            {
                ModelState.AddModelError("Categories", "Parent kateqoriyasi sechin.");
                return View();
            }

            var parentCategory = categories.FirstOrDefault(x => x.ID == categoryId);
            if (parentCategory == null)
                return BadRequest();

            var isExistBlog = await _dbContext.Events.AnyAsync(x => x.Title.ToLower() == events.Title.ToLower());

            if (isExistBlog)
            {
                ModelState.AddModelError("Title", "Bu title-da event mövcuddur!");
                return View();
            }

            if (!events.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil olmalıdır");
                return View();
            }

            if (events.Photo.Length > 1024 * 1000)
            {
                ModelState.AddModelError("Photo", "Yükləməyiniz şəkil 1Mb-dan az olmalıdır");
                return View();
            }

            var webRootPath = _environment.WebRootPath;
            var fileName = $"{Guid.NewGuid()}-{events.Photo.FileName}";
            var path = Path.Combine(webRootPath, "img/event", fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await events.Photo.CopyToAsync(fileStream);

            var eventCategories = new List<EventCategories>();

            var eventCategory = new EventCategories
            {
                EventID = events.ID,
                CategoryID = categoryId
            };
            eventCategories.Add(eventCategory);

            events.EventCategories = eventCategories;




            var eventSpeakers = new List<EventSpeaker>();

            var eventSpeaker = new EventSpeaker
            {
                EventID = events.ID,
                SpikerID = speakerId
            };
            eventSpeakers.Add(eventSpeaker);

            events.EventSpeaker = eventSpeakers;


            events.EventImage = fileName;
            await _dbContext.Events.AddAsync(events);
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

            var events = await _dbContext.Events
                .Where(x => x.ID == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (events == null)
                return NotFound();

            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id == null)
                return NotFound();

            var events = await _dbContext.Events.FindAsync(id);
            if (events == null)
                return NotFound();

            events.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var events = await _dbContext.Events.FindAsync(id);
            var eventdetail = await _dbContext.EventDetails.Where(x => x.EventID == id).ToListAsync();
            ViewBag.EventDetail = eventdetail;
            if (events == null)
                return NotFound();
            if (eventdetail == null)
                return NotFound();

            return View(events);

        }

        public async Task<IActionResult> Update(int? id)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var spiker = await _dbContext.Speakers.ToListAsync();
            ViewBag.Speakers = spiker;

            var eventCategories = await _dbContext.EventCategories.Where(x => x.EventID == id).ToListAsync();
            ViewBag.eventCategories = eventCategories;

            var eventDetail = await _dbContext.EventDetails.Where(x => x.EventID == id).ToListAsync();
            ViewBag.eventDetail = eventDetail;

            if (id == null)
                return NotFound();

            var events = await _dbContext.Events.FirstOrDefaultAsync(x => x.ID == id);
            if (events == null)
                return NotFound();

            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Event events)
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;

            var spiker = await _dbContext.Speakers.ToListAsync();
            ViewBag.Speakers = spiker;

            var eventCategories = await _dbContext.EventCategories.Where(x => x.EventID == id).ToListAsync();
            ViewBag.eventCategories = eventCategories;

            var eventDetail = await _dbContext.EventDetails.Where(x => x.EventID == id).ToListAsync();
            ViewBag.eventDetail = eventDetail;

            if (id == null)
                return NotFound();

            if (id != events.ID)
                return BadRequest();

            var existEvent = await _dbContext.Events.FindAsync(id);
            if (existEvent == null)
                return NotFound();

            if (events.Photo != null)
            {
                if (!events.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yuklediyiniz shekil olmalidir.");
                    return View(existEvent);
                }

                if (!events.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "1 mb-dan az olmalidir.");
                    return View(existEvent);
                }

                var path = Path.Combine(Constants.ImageFolderPath, existEvent.EventImage);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await events.Photo.GenerateFile(Constants.ImageFolderPath);
                existEvent.EventImage = fileName;
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
