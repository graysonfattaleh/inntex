using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurialSite.Models.ViewModels
{
    public class AddBurialSiteViewModel
    {

        public Burial Burial { get; set; }

        public IEnumerable<SelectListItem> BasilList { get; set; }
        public IEnumerable<SelectListItem> CranialStructureList { get; set; }
    }

}
