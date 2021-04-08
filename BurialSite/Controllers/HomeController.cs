using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BurialSite.Models;

namespace BurialSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ArcDBContext _context;

        public HomeController(ILogger<HomeController> logger,ArcDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        // READ AND FILTER FUNCTIONS FOR USERS
        // pull up home feed
        public IActionResult Index()
        {
            List<TestEnt> tests = _context.Tests.ToList();
           
            return View(tests);
        }

        // Filter Function

        public IActionResult FilterResults()
        {
            List<TestEnt> tests = _context.Tests.ToList();

            return View("Index", tests);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
