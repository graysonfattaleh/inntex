using System;
using BurialSite.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using BurialSite.Models.ViewModels;

namespace BurialSite.Components
{
    public class FilterListViewComponent : ViewComponent
    {
        private ArcDBContext _context;
        public FilterListViewComponent(ArcDBContext context)
        {
            _context = context;
        }




        public IViewComponentResult Invoke()
        {

            // get locationoptions for selector
            List<BurialLocation> locations = _context.BurialLocations.ToList();
            Dictionary<string, int> locationvalues = new Dictionary<string, int>();

            locationvalues["All"] = -1;
            foreach(BurialLocation bl in locations)
            {

                string namestring = $"{bl.Dig_Site_Name} NS: {bl.N_S_Grid_Site_Lower}/ {bl.N_S_Grid_Site_Upper} EW: {bl.E_W_Grid_Site_Lower}/ {bl.E_W_Grid_Site_Upper} ";
                locationvalues[namestring] = bl.BurialLocationId;

            }
             
            // get distinct values dynamically AHH 
            FilterOptions filterOptions = new FilterOptions
            {
                genderoptions = _context.Burials.Select(b => b.Sex).Distinct().ToList(),
                Locations = locationvalues
                
                
            };

            return View(filterOptions);
         
        }

    }
}
