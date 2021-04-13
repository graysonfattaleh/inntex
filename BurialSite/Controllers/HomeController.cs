using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

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


        public int pageSize = 30;
        // READ AND FILTER FUNCTIONS FOR USERS
        // pull up home feed

        public IActionResult Index()
        {
            List<TestEnt> tests = _context.Tests.ToList();
           
            return View(tests);
        }


        // view site
        public IActionResult ViewSites( int pagenumber = 1)
        {


            IEnumerable<Burial> burials = _context.Burials.Include(b => b.BurialLocation);
            int totalBurials = burials.Count();

            AddSiteViewModel BurialList = new AddSiteViewModel()
            {
                // get burials
                Burials = _context.Burials.Include(b => b.BurialLocation)
                .OrderBy(b => b.BurialID).Skip((pagenumber - 1) * pageSize).Take(pageSize),
                PaginationInfo = new PageNumberingInfo
                {
                    CurrentPage = pagenumber,
                    NumItemsPerPage = pageSize,
                    // either uses all books or just books in cat
                    TotalNumItems = totalBurials
                       
                }
            };

            return View(BurialList);
        }
        // Filter Function

        public IActionResult FilterBurials(int locationfilter, string genderfilter, decimal depthfilter, int pagenumber = 1)
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

            return View("ViewSites", FilteredBurialList);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
