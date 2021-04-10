using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurialSite.Models.ViewModels
{
    public class EditBurialViewModel
    {

        public EditBurialViewModel()
        {
            // get options for lists that are vairables 
            List<SelectListItem> CranialOptions = new List<SelectListItem>();
            CranialOptions.Add(new SelectListItem { Text = "Closed", Value = "Closed" });
            CranialOptions.Add(new SelectListItem { Text = "Open", Value = "Open" });
            CranialOptions.Add(new SelectListItem { Text = "Partially Open", Value = "Partially Open" });
            List<SelectListItem> BasilOptions = new List<SelectListItem>();
            BasilOptions.Add(new SelectListItem { Text = "Closed", Value = "Closed" });
            BasilOptions.Add(new SelectListItem { Text = "Open", Value = "Open" });

            BasilList = BasilOptions;
            CranialStructureList = CranialOptions;
        }
        public IEnumerable<SelectListItem> BasilList { get; set; }
        public IEnumerable<SelectListItem> CranialStructureList { get; set; }
        public Burial Burial { get; set; }
    }

    
}
