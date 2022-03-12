using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Detail()
        {
            return View();
        }
    }
}
