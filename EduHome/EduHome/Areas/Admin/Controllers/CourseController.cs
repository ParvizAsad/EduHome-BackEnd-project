﻿using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExportFile()
        {
            return View();
        }
    }
}
