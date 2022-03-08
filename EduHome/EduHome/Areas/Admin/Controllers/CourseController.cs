using EduHome.DataAccessLayer;
using EduHome.Models;
using EduHome.ViewModels;
using FrontToBack.Areas.Admin.Data;
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
            var courses = await _dbContext.Courses.Skip((page - 1) * take).Take(take).ToListAsync();
            return View(courses);
        }

        public IActionResult ExportFile()
        {
            return View();
        }

        public async Task<IActionResult> CreateAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course, int categoryId)
        {
          
            var categories = await _dbContext.Categories.Where(x=> x.IsDeleted==false).ToListAsync();
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

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _dbContext.Courses
                .Where(x => x.Id == id)
                .Include(x => x.CourseCategories).ThenInclude(x => x.Course)
                .FirstOrDefaultAsync();
            if (course == null)
                return NotFound();

            var parentCategories = await _dbContext.Categories
               .Where(x => x.IsDeleted == false)
               .Include(x => x.Courses.Where(y => y.IsDeleted == false))
               .ToListAsync();
            var childCategories = parentCategories[0].Courses.ToList();

            var selectedParentCategoryId = course.CourseCategories
                .FirstOrDefault(x => x.Categories.IsDeleted == false)
                .CategoriesID;
            var selectedChildCategoryId = course.CourseCategories
                .FirstOrDefault(x => x.Categories.IsDeleted == false )
                .CategoriesID;

            var courseViewModel = new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                //Assestments = course.CourseDetail.Assestments,
                //AboutDescription = course.CourseDetail.AboutDescription,
                //ApplyDescription = course.CourseDetail.ApplyDescription,
                //CertificaitonDescription = course.CourseDetail.CertificaitonDescription,
                //DurationTime = course.CourseDetail.DurationTime,
                //ImagePath = course.ImagePath,
                //Language = course.CourseDetail.Language,
                //LessonDurationTime = course.CourseDetail.LessonDurationTime,
                //SkillLevel = course.CourseDetail.SkillLevel,
                //Price = course.CourseDetail.Price,
                //StartDay = course.CourseDetail.StartDay,
                studentCapacity = course.CourseDetail.studentCapacity,
                ParentCategories = parentCategories,
                SelectedParentCategoriesId = selectedParentCategoryId,
            };

            return View(courseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CourseViewModel courseViewModel)
        {
            if (id == null)
                return NotFound();

            if (id != courseViewModel.Id)
                return BadRequest();

            var existCourse = await _dbContext.Courses
                .Where(x => x.Id == id)
                .Include(x => x.CourseCategories).ThenInclude(x => x.Categories)
                .FirstOrDefaultAsync();
            if (existCourse == null)
                return NotFound();

            var parentCategories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false )
                .ToListAsync();

            courseViewModel.ParentCategories = parentCategories;

            if (!ModelState.IsValid)
                return View(courseViewModel);

            var isExistProduct = await _dbContext.Courses
                .AnyAsync(x => x.Name == courseViewModel.Name && x.Id != courseViewModel.Id);
            if (isExistProduct)
            {
                ModelState.AddModelError("Name", "Bu adda mehsul movcuddur.");
                return View(courseViewModel);
            }

            var existParentCategory = parentCategories
                .FirstOrDefault(x => x.IsDeleted == false &&
                                     x.ID == courseViewModel.SelectedParentCategoriesId);
            if (existParentCategory == null)
                return NotFound();

            if (courseViewModel.SelectedParentCategoriesId != null)
            {
                if (!existParentCategory.CourseCategories.Any(x => x.Id == courseViewModel.SelectedParentCategoriesId))
                    return NotFound();

                existCourse.CourseCategories
                    .FirstOrDefault(x => x.Categories.IsDeleted == false )
                    .CategoriesID = (int)courseViewModel.SelectedParentCategoriesId;
            }

            if (courseViewModel.Photo != null && courseViewModel.Photo.Length > 0)
            {
                
                    if (!courseViewModel.Photo.IsImage())
                    {
                        ModelState.AddModelError("Photos", $"{courseViewModel.Photo.Name} Duzgun shekil formati sechin.");
                        return View();
                    }

                    if (!courseViewModel.Photo.IsAllowedSize(1))
                    {
                        ModelState.AddModelError("Photos", $"{courseViewModel.Photo.Name} 1Mb-dan artiq ola bilmez.");
                        return View();
                    }

                    var fileName = await courseViewModel.Photo.GenerateFile(Constants.ImageFolderPath);

                courseViewModel.ImagePath = fileName;
                    await _dbContext.SaveChangesAsync();
               
            }



            existCourse.Id = courseViewModel.Id;
            existCourse.Name = courseViewModel.Name;
            existCourse.Description = courseViewModel.Description;
            existCourse.CourseDetail.Assestments = courseViewModel.Assestments;
            existCourse.CourseDetail.AboutDescription = courseViewModel.AboutDescription;
            existCourse.CourseDetail.ApplyDescription = courseViewModel.ApplyDescription;
            existCourse.CourseDetail.CertificaitonDescription = courseViewModel.CertificaitonDescription;
            existCourse.CourseDetail.DurationTime = courseViewModel.DurationTime;
            existCourse.ImagePath = courseViewModel.ImagePath;
            existCourse.CourseDetail.Language = courseViewModel.Language;
            existCourse.CourseDetail.LessonDurationTime = courseViewModel.LessonDurationTime;
            existCourse.CourseDetail.SkillLevel = courseViewModel.SkillLevel;
            existCourse.CourseDetail.Price = courseViewModel.Price;
            existCourse.CourseDetail.StartDay = courseViewModel.StartDay;
                existCourse.CourseDetail.studentCapacity = courseViewModel.studentCapacity;

            existCourse.CourseCategories
                .FirstOrDefault(x => x.Categories.IsDeleted == false )
                .CategoriesID = courseViewModel.SelectedParentCategoriesId;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        //public async Task<IActionResult> Update(int? id)
        //{
        //    var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
        //    ViewBag.Categories = categories;



        //    if (id == null)
        //        return NotFound();

        //    var course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);

        //    if (course == null)
        //        return NotFound();

        //    var selectedParentCategoryId = course.CourseCategories.Where(x => x.CourseID == id && x.Categories.IsDeleted == false);


        //    var parentCategories = await _dbContext.Categories
        //     .Where(x => x.IsDeleted == false )
        //     .ToListAsync();

        //    var courseViewModel = new CourseViewModel
        //    {
        //        Id = course.Id,
        //        Name = course.Name,
        //        Description = course.Description,
        //    Assestments=course.CourseDetail.Assestments,
        //    AboutDescription=course.CourseDetail.AboutDescription,
        //    ApplyDescription=course.CourseDetail.ApplyDescription,
        //    CertificaitonDescription=course.CourseDetail.CertificaitonDescription,
        //    DurationTime=course.CourseDetail.DurationTime,
        //    ImagePath=course.ImagePath,
        //    Language=course.CourseDetail.Language,
        //    LessonDurationTime=course.CourseDetail.LessonDurationTime,
        //    ParentCategories=parentCategories,
        //    SkillLevel=course.CourseDetail.SkillLevel,
        //    Price=course.CourseDetail.Price,
        //    StartDay=course.CourseDetail.StartDay,  
        //    studentCapacity=course.CourseDetail.studentCapacity,

        //    };

        //    return View(courseViewModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int? id, CourseViewModel courseViewModel)
        //{
        //    var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
        //    ViewBag.Categories = categories;


        //    if (id == null)
        //        return NotFound();

        //    if (id != courseViewModel.Id)
        //        return BadRequest();

        //    if (!ModelState.IsValid)
        //        return View();

        //    var existCourse = await _dbContext.Courses.FindAsync(id);
        //    if (existCourse == null)
        //        return NotFound();

        //    var isExist = await _dbContext.Courses
        //        .AnyAsync(x => x.Name.ToLower().Trim() == courseViewModel.Name.ToLower().Trim() && x.Id != id);
        //    if (isExist)
        //    {
        //        ModelState.AddModelError("Name", "Eyni adda course movcuddur");
        //        return View();
        //    }

        //    existCourse.Name = courseViewModel.Name;

        //    await _dbContext.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int? id, ProductViewModel productViewModel)
        //{
        //    if (id == null)
        //        return NotFound();

        //    if (id != productViewModel.Id)
        //        return BadRequest();

        //    var existProduct = await _dbContext.Products
        //        .Where(x => x.Id == id)
        //        .Include(x => x.ProductImages)
        //        .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
        //        .FirstOrDefaultAsync();
        //    if (existProduct == null)
        //        return NotFound();

        //    var parentCategories = await _dbContext.Categories
        //        .Where(x => x.IsDeleted == false && x.IsMain)
        //        .Include(x => x.Children.Where(y => y.IsDeleted == false))
        //        .ToListAsync();
        //    var childCategories = parentCategories[0].Children.ToList();

        //    productViewModel.ParentCategories = parentCategories;
        //    productViewModel.ChildCategories = childCategories;
        //    productViewModel.ProductImages = existProduct.ProductImages.ToList();

        //    if (!ModelState.IsValid)
        //        return View(productViewModel);

        //    var isExistProduct = await _dbContext.Products
        //        .AnyAsync(x => x.Name == productViewModel.Name && x.Id != productViewModel.Id);
        //    if (isExistProduct)
        //    {
        //        ModelState.AddModelError("Name", "Bu adda mehsul movcuddur.");
        //        return View(productViewModel);
        //    }

        //    var existParentCategory = parentCategories
        //        .FirstOrDefault(x => x.IsDeleted == false &&
        //                             x.IsMain &&
        //                             x.Id == productViewModel.SelectedParentCategoryId);
        //    if (existParentCategory == null)
        //        return NotFound();

        //    if (productViewModel.SelectedChildCategoryId != null)
        //    {
        //        if (!existParentCategory.Children.Any(x => x.Id == productViewModel.SelectedChildCategoryId))
        //            return NotFound();

        //        existProduct.ProductCategories
        //            .FirstOrDefault(x => x.Category.IsDeleted == false && x.Category.IsMain == false)
        //            .CategoryId = (int)productViewModel.SelectedChildCategoryId;
        //    }

        //    if (productViewModel.Photos != null && productViewModel.Photos.Length > 0)
        //    {
        //        foreach (var photo in productViewModel.Photos)
        //        {
        //            if (!photo.IsImage())
        //            {
        //                ModelState.AddModelError("Photos", $"{photo.Name} Duzgun shekil formati sechin.");
        //                return View();
        //            }

        //            if (!photo.IsAllowedSize(1))
        //            {
        //                ModelState.AddModelError("Photos", $"{photo.Name} 1Mb-dan artiq ola bilmez.");
        //                return View();
        //            }

        //            var fileName = await photo.GenerateFile(Constants.ImageFolderPath);

        //            var productImage = new ProductImage
        //            {
        //                Name = fileName,
        //                ProductId = (int)id
        //            };

        //            await _dbContext.ProductImages.AddAsync(productImage);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //    }

        //    existProduct.Name = productViewModel.Name;
        //    existProduct.Description = productViewModel.Description;
        //    existProduct.Brand = productViewModel.Brand;
        //    existProduct.Code = productViewModel.Code;
        //    existProduct.ExTax = productViewModel.ExTax;
        //    existProduct.Tags = productViewModel.Tags;
        //    existProduct.Rate = productViewModel.Rate;
        //    existProduct.Price = productViewModel.Price;
        //    existProduct.DiscountPercent = productViewModel.DiscountPercent;

        //    existProduct.ProductCategories
        //        .FirstOrDefault(x => x.Category.IsDeleted == false && x.Category.IsMain)
        //        .CategoryId = productViewModel.SelectedParentCategoryId;

        //    await _dbContext.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

    }
}
