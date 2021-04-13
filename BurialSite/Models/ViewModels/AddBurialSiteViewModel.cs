using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurialSite.Models.ViewModels
{
    public class AddBurialSiteViewModel : EditBurialViewModel
    {
        public AddBurialSiteViewModel(ArcDBContext context) : base(context) {}
    }

}
