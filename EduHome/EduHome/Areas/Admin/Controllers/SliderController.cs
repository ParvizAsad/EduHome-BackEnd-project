using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Data;
using System.IO;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SliderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int take = 10;
            ViewBag.totalpage = Math.Ceiling((decimal)_dbContext.Sliders.Count() / take);
            ViewBag.currentpage = page;
            var categories = await _dbContext.Sliders.Skip((page - 1) * take).Take(take).ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var isExistCategory = await _dbContext.Sliders.AnyAsync(x => x.Title.ToLower() == slider.Title.ToLower());

            if (isExistCategory)
            {
                ModelState.AddModelError("Title", "Bu adda title mövcuddur!");
                return View();
            }

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", $"{slider.Photo.FileName} - Yuklediyiniz shekil olmalidir.");
                return View();
            }

            if (!slider.Photo.IsAllowedSize(1))
            {
                ModelState.AddModelError("Photo", $"{slider.Photo.FileName} - shekil 1 mb-dan az olmalidir.");
                return View();
            }

            var fileName = await slider.Photo.GenerateFile(Constants.ImageFolderPath);

            var sliders = new Slider { Path = fileName,
            Title=slider.Title,
            SubTitle=slider.SubTitle
            };

            await _dbContext.Sliders.AddAsync(sliders);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var sliderImage = await _dbContext.Sliders.FindAsync(id);
            if (sliderImage == null)
                return NotFound();

            return View(sliderImage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSliderImage(int? id)
        {
            if (id == null)
                return NotFound();

            var slider = await _dbContext.Sliders.FindAsync(id);
            if (slider == null)
                return NotFound();
            _dbContext.Sliders.Remove(slider);
            await _dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var sliderImage = await _dbContext.Sliders.FirstOrDefaultAsync(x => x.ID == id);
            if (sliderImage == null)
                return NotFound();

            return View(sliderImage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            if (id == null)
                return NotFound();

            if (id != slider.ID)
                return BadRequest();

            var existSliderImage = await _dbContext.Sliders.FindAsync(id);
            if (existSliderImage == null)
                return NotFound();

            if (slider.Photo!=null)
            {
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yuklediyiniz shekil olmalidir.");
                    return View(existSliderImage);
                }

                if (!slider.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "1 mb-dan az olmalidir.");
                    return View(existSliderImage);
                }

                var path = Path.Combine(Constants.ImageFolderPath, existSliderImage.Path);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
              var fileName = await slider.Photo.GenerateFile(Constants.ImageFolderPath);
            existSliderImage.Path = fileName;
            }
           

            existSliderImage.SubTitle=slider.SubTitle;
            existSliderImage.Title=slider.Title;


            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
