using EduHome.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class TestimontalViewComponent:ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public TestimontalViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimontial = await _dbContext.Testimontials.SingleOrDefaultAsync();

            return View(testimontial);
        }
    }
}
