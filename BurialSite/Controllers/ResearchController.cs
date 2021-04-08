using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using BurialSite.Services;
using Microsoft.AspNetCore.Http;
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
        private readonly IS3Service _s3storage;
        // get context stuff
        public ResearchController(ILogger<HomeController> logger, ArcDBContext context, IS3Service storage)
        {
            _logger = logger;
            _context = context;
            _s3storage = storage;
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
        public IActionResult UploadPhotos()
        {

            return View(new SavePhotoViewModel { });
        }

        [HttpPost]

        public async Task<IActionResult> SavePhotos(SavePhotoViewModel SavePhoto)
        {
            // save iploaded photo yeet

      
            if (ModelState.IsValid)
            {

                await _s3storage.AddItem(SavePhoto.PhotoFile, "testGuy");
               //string fileName = UploadFile(SavePhoto);
                return View("AddSite");
            }
            else
            {
                return View("UploadPhotos");
            }

          
        }

        public IActionResult CreatePhoto()
        {

            return View();
        }

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
