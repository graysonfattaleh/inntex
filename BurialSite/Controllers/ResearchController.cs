using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BurialSite.Controllers
{
    public class ResearchController : Controller
    {
        // context stuff
        private readonly ILogger<HomeController> _logger;
        private ArcDBContext _context;
        // get context stuff
        public ResearchController(ILogger<HomeController> logger, ArcDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            List<TestEnt> tests = _context.Tests.ToList();

            return View(tests);
        }


        //CRUD FUNCTIONS FOR RESEARCHERS-------------------

        //Add Burial Site
        public IActionResult AddSite()
        { 

            return View();
        }

        //Edit BUrial Site

        //Read Burial Site Details

        //Upload Photos

        // Delete Burial Site?? (just admin maybe?)



        // ADMIN CRUD----------------------------------------

        // link to portal
        public IActionResult ManageUsers()
        {

            return View();
        }

        //Add Researcher

        //Edit Researcher

        // Delete Researcher
    }
}
