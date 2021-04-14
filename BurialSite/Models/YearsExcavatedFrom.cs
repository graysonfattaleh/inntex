using System;
using System.Collections.Generic;

namespace BurialSite.Models
{
    /// <summary>
    ///Future to use table that notes metadata about each location in the location table. 
    ///Can include things like the years the place had excavations. Good for graphing.
    /// </summary>
    
    public class YearsExcavatedFrom
    {
        public int YearsExcavatedFromId { get; set; }

        public string Year { get; set; }

        public virtual ICollection<BurialLocation> BurialLocation { get; set; }

    }

}
