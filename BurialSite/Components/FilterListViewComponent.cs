using System;
using BurialSite.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using BurialSite.Models.ViewModels;
using System.Reflection;

namespace BurialSite.Components
{
    /// <summary>
    /// View component for filtering the list
    /// </summary>
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
            // generate all customfilter keys
     
            IEnumerable<PropertyInfo> customfilterproperties = _context.Burials.FirstOrDefault().GetType().GetProperties().ToList();
            List<string> customfilteroptions = new List<string>();
            // default if nothing selected
            customfilteroptions.Add("None");
            foreach(PropertyInfo prop in customfilterproperties)
            {
                customfilteroptions.Add(prop.Name);
            }

        // get distinct values dynamically AHH 
        FilterOptions filterOptions = new FilterOptions
            {
                genderoptions = _context.Burials.Select(b => b.Sex).Distinct().ToList(),
                Locations = locationvalues,
                CustomFilterOptions = customfilteroptions
                
                
            };

            return View(filterOptions);
         
        }

    }
}
