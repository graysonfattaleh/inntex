using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurialSite.Models.ViewModels
{
    public class AddSiteViewModel
    {
        public IEnumerable<Burial> Burials { get; set; }
    }
}
