using EduHome.Areas.Admin.Data;
using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ssSpeakerController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public ssSpeakerController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Speakers.Count() / take);
            ViewBag.currentpage = page;
            var speaker = await _dbContext.Speakers.Where(x => x.IsDeleted == false).Skip((page - 1) * take).Take(take).ToListAsync();
            return View(speaker);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var isExistSpeaker = await _dbContext.Speakers.AnyAsync(x => x.Name.ToLower() == speaker.Name.ToLower());

            if (isExistSpeaker)
            {
                ModelState.AddModelError("Name", "Bu adda Name mövcuddur!");
                return View();
            }

            if (!speaker.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", $"{speaker.Photo.FileName} - Yuklediyiniz shekil olmalidir.");
                return View();
            }

            if (!speaker.Photo.IsAllowedSize(1))
            {
                ModelState.AddModelError("Photo", $"{speaker.Photo.FileName} - shekil 1 mb-dan az olmalidir.");
                return View();
            }

            var webRootPath = _environment.WebRootPath;
            var fileName = $"{Guid.NewGuid()}-{speaker.Photo.FileName}";
            var path = Path.Combine(webRootPath, "img/event", fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await speaker.Photo.CopyToAsync(fileStream);

            var speakers = new Speaker
            {
                ImagePath = fileName,
                Name = speaker.Name,
                Job = speaker.Job
            };

            await _dbContext.Speakers.AddAsync(speakers);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var speaker = await _dbContext.Speakers.FindAsync(id);

            if (speaker == null)
                return NotFound();

            return View(speaker);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var speaker = await _dbContext.Speakers
                .Where(x => x.ID == id && x.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (speaker == null)
                return NotFound();

            return View(speaker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSpeaker(int? id)
        {
            if (id == null)
                return NotFound();

            var speaker = await _dbContext.Speakers.FindAsync(id);
            if (speaker == null)
                return NotFound();

            speaker.IsDeleted = true;
            await _dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var speaker = await _dbContext.Speakers.FirstOrDefaultAsync(x => x.ID == id);

            if (speaker == null)
                return NotFound();

            return View(speaker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Speaker speaker)
        {
            if (id == null)
                return NotFound();

            if (id != speaker.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return View();

            var existspeaker = await _dbContext.Speakers.FindAsync(id);
            if (existspeaker == null)
                return NotFound();

            var isExist = await _dbContext.Speakers
                .AnyAsync(x => x.Name.ToLower().Trim() == speaker.Name.ToLower().Trim() && x.ID != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Eyni adda speaker movcuddur");
                return View();
            }

            if (speaker.Photo != null)
            {
                if (!speaker.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yuklediyiniz shekil olmalidir.");
                    return View(existspeaker);
                }

                if (!speaker.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "1 mb-dan az olmalidir.");
                    return View(existspeaker);
                }

                var path = Path.Combine(Constants.ImageFolderPath, existspeaker.ImagePath);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await speaker.Photo.GenerateFile(Constants.ImageFolderPath);
                existspeaker.ImagePath = fileName;
            }

            existspeaker.Name = speaker.Name;
            existspeaker.Job = speaker.Job;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
