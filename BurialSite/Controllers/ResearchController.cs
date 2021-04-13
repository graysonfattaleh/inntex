﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using BurialSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

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

        //items per page
        public int pageSize = 30;


        //CRUD FUNCTIONS FOR RESEARCHERS-------------------

        // Burial Site List /////////////////////////////////////////////
        [Authorize(Policy = "researcherpolicy")]

        public IActionResult AddSite(string filterer, int pagenumber = 1)
        {
            AddSiteViewModel BurialList = new AddSiteViewModel()
            {
                // get burials
                Burials = _context.Burials.Include(b => b.BurialLocation)
                .OrderBy(b=>b.BurialID).Skip((pagenumber -1 ) * pageSize).Take(pageSize),
                  PaginationInfo = new PageNumberingInfo
                  {
                      CurrentPage = pagenumber,
                      NumItemsPerPage = pageSize,
                      // either uses all books or just books in cat
                      TotalNumItems =
                        filterer == null ? _context.Burials.Count() : _context.Burials.Where(b => b.Category == filterer).Count()
                  }
            };
            return View(BurialList);
        }

        // Filter Burial List///////////////////////////////////////////////
        [Authorize(Policy = "researcherpolicy")]

        public IActionResult FilterBurials(int locationfilter,string genderfilter,decimal depthfilter, int pagenumber = 1)
        {
            // get filteted list

            IEnumerable<Burial> burials = _context.Burials.
                Where(b => (genderfilter == null || genderfilter == b.Sex) &
                (depthfilter == 0 || b.Depth < depthfilter) &
                (locationfilter == -1 || locationfilter == 0 || b.BurialLocationId == locationfilter)
                )
                .Include(b => b.BurialLocation);
       
            // fcount full set then filter
            int TotalBurialsInt = burials.Count();
            burials = burials.OrderBy(b => b.BurialID).Skip((pagenumber - 1) * pageSize).Take(pageSize);

            // get stored key values
            AddSiteViewModel FilteredBurialList = new AddSiteViewModel()
            {
                // get burials
                Burials = burials,
                PaginationInfo = new PageNumberingInfo
                { 
                    CurrentPage = pagenumber,
                    NumItemsPerPage = pageSize,
                    // either uses all books or just books in cat
                    TotalNumItems = TotalBurialsInt
                },
                
            };

            return View("AddSite", FilteredBurialList);
        }


        // View Burial Detials //////////////////////////////////////////////
        [HttpPost]
        public IActionResult BurialDetails(int BurialId)
        {
            BurialDetailsViewModels burialDetails = new BurialDetailsViewModels(_context, BurialId);
            
            return View(burialDetails);
        }


        // ADD BURIAL ///////////////////////////////////////////////////////
        [Authorize(Policy = "researcherpolicy")]
        public IActionResult CreateBurial()
        {
            AddBurialSiteViewModel burialSiteViewModel = new AddBurialSiteViewModel();
            return View(burialSiteViewModel);

        }
        [Authorize(Policy = "researcherpolicy")]
        [HttpPost]
        public IActionResult SaveBurial(Burial burial)
        {
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
        [Authorize(Policy = "researcherpolicy")]
        public IActionResult EditBurial(int BurialId)
        {
            Burial burial = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();
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
        [Authorize(Policy = "researcherpolicy")]
        public IActionResult UploadPhotos(int BurialId)
        {

            Burial burial = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();

            return View(new SavePhotoViewModel {
                Burial= burial
            });
        }

        [HttpPost]
        [Authorize(Policy = "researcherpolicy")]
        public async Task<IActionResult> SavePhotos(SavePhotoViewModel SavePhoto, int BurialId)
        {
            // save iploaded photo yeet
            if (ModelState.IsValid)
            {
                string url =  await _s3storage.AddItem(SavePhoto.PhotoFile, "testGuy");
                Burial burial_to_add = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();

                FileUrl FileRecord = new FileUrl(_context)
                {
                    Url = url,
                    Type = SavePhoto.Type,
                    Burial = burial_to_add,
                    BurialID =  burial_to_add.BurialID
                 };


                _context.Add(FileRecord);
                _context.SaveChanges();
                return Redirect("/Research/AddSite");
            }
            else
            {
                return View("UploadPhotos");

            } 
        }


        // Delete Burial Site?? ///////////////////////////////////////////
        [Authorize(Policy = "superadminpolicy")]
        public IActionResult DeleteBurialSite(int BurialId)
        {

            Burial burial = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();
            _context.Remove(burial);
            _context.SaveChanges();
            return View();
        }

        // NOTES CRUD----------------------------------------
        [Authorize(Policy = "researcherpolicy")]
        public IActionResult AddNote(string NoteData, string NoteType, int BurialId)
        {
            // make new note
            try {
                Notes note_to_add = new Notes
                {
                    Data = NoteData,
                    Type = NoteType,
                    BurialID = BurialId
                };

                _context.Add(note_to_add);
                _context.SaveChanges();

                Burial burial = _context.Burials.Include(b => b.BurialLocation).Where(b => b.BurialID == BurialId).FirstOrDefault();
                BurialDetailsViewModels burialDetails = new BurialDetailsViewModels(_context,BurialId);
                
                return View("BurialDetails",burialDetails);
            }
            catch
            {
                return View("AddNoteError");
            }
          
        }

        public IActionResult DeleteNote(int NoteId,int BurialId)
        {
            Notes note = _context.Notes.Where(b => b.NotesId == NoteId).FirstOrDefault();
            // remove note
            _context.Remove(note);
            _context.SaveChanges();
            // New Details
            BurialDetailsViewModels burialDetails = new BurialDetailsViewModels(_context, BurialId);
            return View("BurialDetails",burialDetails);
            
        }

        //ADMIN CRUD LOCATED IN ROLE CONTROLLER/////////////////////////////////////////////

        // Delete Researcher/////////////////////////////////////////////
    }
}
