using EduHome.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public AboutViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bio = await _dbContext.Abouts.SingleOrDefaultAsync();

            return View(bio);
        }
    }
}
