using System;
using System.Collections.Generic;

namespace BurialSite.Models
{
    public class YearsExcavatedFrom
    {
        public int YearsExcavatedFromId { get; set; }

        public string Year { get; set; }

        public virtual ICollection<BurialLocation> BurialLocation { get; set; }

    }

}
