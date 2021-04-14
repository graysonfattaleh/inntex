using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using BurialSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
       // checks user in controller

        public IActionResult FilterBurials(string customfilter, string customfiltervalue,int locationfilter,string genderfilter,decimal depthfilter, int pagenumber = 1 )
        {
            // get filteted from initial filters list

            IEnumerable<Burial> initburials = _context.Burials.
            Where(b => (genderfilter == null || genderfilter == b.Sex) &
            (depthfilter == 0 || b.Depth < depthfilter) &
            (locationfilter == -1 || locationfilter == 0 || b.BurialLocationId == locationfilter) 
            
            );

            // fcount full set then filter
            // needed to subtract to get pagination info but optomize speeds
            

            int TotalBurialsInt = initburials.Count();
            List<Burial> burials_to_pass = new List<Burial>();
            // big custom filter guy 
            if (customfilter != "None"& customfilter != null)
            {
                foreach (Burial burial in initburials)
                {
                    foreach (PropertyInfo prop in burial.GetType().GetProperties())
                    {
                        if (prop.Name == customfilter)
                        {
                            var comparevalue = prop.GetValue(burial);
                                if (comparevalue is string  )
                                {
                                    if( comparevalue.ToString().ToLower().Contains(customfiltervalue.ToLower()) == true)
                                        {
                                            burials_to_pass.Add(burial);
                                        }
                                   
                                }
                           
                        }
                    }
                }
                // get
                TotalBurialsInt = burials_to_pass.Count();
                burials_to_pass =  burials_to_pass.OrderBy(b => b.BurialID).Skip((pagenumber - 1) * pageSize).Take(pageSize).ToList();
                
            }
            else
            {
                burials_to_pass = initburials.ToList();
                burials_to_pass = burials_to_pass.OrderBy(b => b.BurialID).Skip((pagenumber - 1) * pageSize).Take(pageSize).ToList();
            }
            // get stored key values
            AddSiteViewModel FilteredBurialList = new AddSiteViewModel()
            {
                // get burials
                Burials = burials_to_pass,
                PaginationInfo = new PageNumberingInfo
                { 
                    CurrentPage = pagenumber,
                    NumItemsPerPage = pageSize,
                    // either uses all books or just books in cat
                    TotalNumItems = TotalBurialsInt
                }, 
            };
            if (User.Identity.IsAuthenticated)
            {
                return View("AddSite", FilteredBurialList);
            }
            return View("ViewSites", FilteredBurialList);
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
            AddBurialSiteViewModel burialSiteViewModel = new AddBurialSiteViewModel(_context);
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
                AddBurialSiteViewModel burialSiteViewModel = new AddBurialSiteViewModel(_context)
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
            EditBurialViewModel BurialEdit = new EditBurialViewModel(_context)
            {
                Burial = burial
            };
            return View(BurialEdit);
        }

        [Authorize(Policy = "researcherpolicy")]
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
                EditBurialViewModel BurialEdit = new EditBurialViewModel(_context)
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
                Burial burial_to_add = _context.Burials.Where(b => b.BurialID == BurialId).FirstOrDefault();
                string url =  await _s3storage.AddItem(SavePhoto.PhotoFile, burial_to_add.DisplayBurialLocation(), SavePhoto.Type );


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


        // Delete Burial Site ///////////////////////////////////////////
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

        [Authorize(Policy = "researcherpolicy")]
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

        [Authorize(Policy = "researcherpolicy")]
        [HttpPost]
        public IActionResult EditNote(int NoteId, int BurialId)
        {
            
            Notes note = _context.Notes.Where(b => b.NotesId == NoteId).FirstOrDefault();
            EditNoteViewModel editViewModel = new EditNoteViewModel(_context, NoteId, BurialId);
            return View(editViewModel);
        }

        [Authorize(Policy = "researcherpolicy")]
        public IActionResult SaveEditedNote(Notes note, int BurialId, string ButtonValue)
        {
            // check if saving
            if(ButtonValue == "SaveEdit")
            {   //check model state 
                if (ModelState.IsValid)
                {  
                    _context.Update(note);
                    _context.SaveChanges();
                    BurialDetailsViewModels burialDetails = new BurialDetailsViewModels(_context, BurialId);
                    return View("BurialDetails", burialDetails);
                }
                else
                {
                    EditNoteViewModel editViewModel = new EditNoteViewModel(_context, note.NotesId, BurialId);
                    return View("EditNote",editViewModel);
                }
            }
            else
            {
                return Redirect("/Research/AddSite");
            }



        }

        //ADMIN CRUD LOCATED IN ROLE CONTROLLER/////////////////////////////////////////////

        // Delete Researcher/////////////////////////////////////////////
    }
}
