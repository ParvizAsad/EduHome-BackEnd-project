using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
