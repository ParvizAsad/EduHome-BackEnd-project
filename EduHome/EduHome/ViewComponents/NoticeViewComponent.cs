using EduHome.DataAccessLayer;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class NoticeViewComponent:ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public NoticeViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var home = await _dbContext.Homes.SingleOrDefaultAsync();

            return View(new HomeViewModel
            {
                Homes = home,
               
            });
        }

    }
}
