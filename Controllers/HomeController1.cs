﻿using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
