using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var homes = await _dbContext.Homes.SingleOrDefaultAsync();
            var bios = await _dbContext.Bios.SingleOrDefaultAsync();

            return View(new HomeViewModel
            {
                Homes = homes,
                Bios = bios

            });
        }
    }
}
