using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeslLoginWithCoockie.Models;
using Microsoft.AspNetCore.Authorization;

namespace TeslLoginWithCoockie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Buy95()
        {
            return View();
        }
        public IActionResult Buy92()
        {
            return View();
        }
    }
}
