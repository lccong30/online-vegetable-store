﻿using Microsoft.AspNetCore.Mvc;

namespace EcommerceV1.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}