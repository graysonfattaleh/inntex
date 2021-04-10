using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using BurialSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        //Add Burial Site /////////////////////////////////////////////
        public IActionResult AddSite()
        {

            AddSiteViewModel BurialList = new AddSiteViewModel()
            {
                Burials = _context.Burials.Include(b => b.BurialLocation).OrderBy(b=>b.BurialID)
            };
            return View(BurialList);
        }


        public IActionResult CreateBurial()
        {

            // list for selector Basil Structure

            List<SelectListItem> CranialOptions = new List<SelectListItem>();
            CranialOptions.Add(new SelectListItem { Text = "Closed", Value = "Closed" });
            CranialOptions.Add(new SelectListItem { Text = "Open", Value = "Open" });
            List<SelectListItem> BasilOptions = new List<SelectListItem>();
            BasilOptions.Add(new SelectListItem { Text = "Closed", Value = "Closed" });
            BasilOptions.Add(new SelectListItem { Text = "Open", Value = "Open" });


            AddBurialSiteViewModel burialSiteViewModel = new AddBurialSiteViewModel
            {
                BasilList = BasilOptions,
                CranialStructureList = CranialOptions
          };


            return View(burialSiteViewModel);

        }

        [HttpPost]
        public IActionResult SaveBurial(Burial burial)
        {
            //burial.BurialLocation = _context.BurialLocations.Where(b => burial.BurialLocationId == b.BurialLocationId).FirstOrDefault();

            int new_id = _context.Burials.OrderBy(b => b.BurialID).Last().BurialID + 1;
            burial.BurialID = new_id;
            if (ModelState.IsValid)
            {


                _context.Add(burial);
                _context.SaveChanges();
                return View();
            }
            else
            { 


                AddBurialSiteViewModel burialSiteViewModel = new AddBurialSiteViewModel
                {
               
                    Burial = burial
                };
                return View("CreateBurial", burialSiteViewModel);
            }
          
        }
        //Edit Burial Site/////////////////////////////////////////////
        [HttpPost]
        public IActionResult EditBurial(int BurialId)
        {
            Burial burial = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();


            // makes options for selector lists

            EditBurialViewModel BurialEdit = new EditBurialViewModel
            {
                Burial = burial
            };

            return View(BurialEdit);
        }

        [HttpPost]
        public IActionResult SaveEditedBurial(Burial burial)
        {
            _context.Update(burial);
            _context.SaveChanges();

            if (ModelState.IsValid)
            {
              
                return View();
            }
            else{
                EditBurialViewModel BurialEdit = new EditBurialViewModel
                {
                    Burial = burial
                };

                return View("EditBurial", BurialEdit);
            }
           
        }

        //Read Burial Site Details

        //Upload Photos/////////////////////////////////////////////
        public IActionResult UploadPhotos()
        {
            return View(new SavePhotoViewModel { });
        }


       public IActionResult SavePhoto(Burial burial)
        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SavePhotos(SavePhotoViewModel SavePhoto)
        {
            // save iploaded photo yeet
            if (ModelState.IsValid)
            {
                string url =  await _s3storage.AddItem(SavePhoto.PhotoFile, "testGuy");
                Console.WriteLine($"\n\n PHOTO URL IS : {url} \n\n");
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

        public IActionResult DeleteBurialSite(int BurialId)
        {

            Burial burial = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();
            _context.Remove(burial);
            _context.SaveChanges();
            return View();
        }

        // ADMIN CRUD----------------------------------------

        // link to portal
        public IActionResult ManageUsers()
        {

            return View();
        }

        //Add Researcher/////////////////////////////////////////////

        //Edit Researcher/////////////////////////////////////////////

        // Delete Researcher/////////////////////////////////////////////
    }
}
