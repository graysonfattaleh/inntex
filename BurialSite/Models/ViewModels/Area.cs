using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurialSite.Models.ViewModels
{
    public static class Area
    {
        //Area, 1 = NE, 2 = SE, 3 = SW, 4 = N@
        public static int NE { get; } = 1;
        public static int SE { get; } = 2;
        public static int SW { get; } = 3;
        public static int NW { get; } = 4;
        public static Dictionary<int, string> Areas { get; } = new Dictionary<int, string>() 
        {
            {NE, "NE" },
            {SE, "SE" },
            {SW, "SW" },
            {NW, "NW" }
        };
    }
}
