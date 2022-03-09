﻿using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var bios = await _dbContext.Bios.ToListAsync();
            return View(bios);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var bio = await _dbContext.Bios.FirstOrDefaultAsync(x => x.Id == id);

            if (bio == null)
                return NotFound();

            return View(bio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Bios bios)
        {
            if (id == null)
                return NotFound();

            if (id != bios.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View();

            var existExpertTitle = await _dbContext.Bios.FindAsync(id);
            if (existExpertTitle == null)
                return NotFound();

            existExpertTitle.Logo = bios.Logo;
            existExpertTitle.Number1 = bios.Number1;
            existExpertTitle.Number2 = bios.Number2;
            existExpertTitle.Number3 = bios.Number3;    
            existExpertTitle.PinterestUrl= bios.PinterestUrl;
            existExpertTitle.FacebookUrl= bios.FacebookUrl;
            existExpertTitle.VcontactUrl= bios.VcontactUrl;
            existExpertTitle.TwitterUrl= bios.TwitterUrl;
            existExpertTitle.Description= bios.Description;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
