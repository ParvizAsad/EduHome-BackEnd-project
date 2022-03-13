using EduHome.DataAccessLayer;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var events = await _dbContext.Events.Where(x => x.IsDeleted == false).Take(3).ToListAsync();
            var eventDetail = await _dbContext.EventDetails.ToListAsync();
            var eventCategory = await _dbContext.EventCategories.ToListAsync();
            var eventSpeaker = await _dbContext.EventSpeakers.ToListAsync();

            return View(new HomeViewModel
            {
                Events = events,
                EventDetails = eventDetail,
                EventCategories = eventCategory,
                EventSpeakers = eventSpeaker

            });
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var events = await _dbContext.Events.Where(x=>x.IsDeleted==false).Include(x => x.EventDetail).Include(x=>x.EventSpeaker).Include(c => c.EventCategories.Where(x => x.EventID == id)).FirstOrDefaultAsync(x => x.ID == id);
            var eventsDetail = await _dbContext.EventDetails.Where(x => x.EventID == id).ToListAsync();
            var eventsCategories = await _dbContext.EventCategories.Where(x => x.EventID == id).SingleOrDefaultAsync();
            var eventsSpeaker = await _dbContext.EventSpeakers.Where(x => x.EventID == id).ToListAsync();
            var speakers = await _dbContext.Speakers.Where(x => x.IsDeleted == false).ToListAsync();
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            ViewBag.Categories = categories;
            List<Speaker> spikerList = new List<Speaker>();

            foreach (var speaker in speakers)
            {
                foreach (var item in eventsSpeaker)
                {
                    if (item.SpikerID == speaker.ID)
                    {
                        spikerList.Add(speaker);
                    }
                }
            }
            ViewBag.SpikerList=spikerList;

            var blogs = await _dbContext.Blogs.Where(x => x.IsDeleted == false).Take(3).ToListAsync();
            ViewBag.Blogs = blogs;

            if (events == null)
                return NotFound();

            return View(events);
        }
    }
}
