using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace BurialSite.Models.ViewModels
{
    public class FilterOptions
    { // this willg et the options for the filtefr view component
        public FilterOptions()
        {
            
        }
        public List<string> genderoptions { get; set; }
        public Dictionary<string,int> Locations { get; set; }
        public IEnumerable<string> CustomFilterOptions{ get; set; }

    }
}
