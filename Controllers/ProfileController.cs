﻿using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
