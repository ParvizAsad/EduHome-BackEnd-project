using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
