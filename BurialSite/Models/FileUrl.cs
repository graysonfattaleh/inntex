using System;
using System.Collections.Generic;
using System.Linq;

namespace BurialSite.Models
{
    /// <summary>
    /// The necessary wrapper class to have our FileUrl class use the primary database context.
    /// </summary>
    public class FileUrl
    {
        private readonly ArcDBContext _context;
        public FileUrl(ArcDBContext context)
        {
            _context = context;
        }
        public int FileUrlId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }

        public int BurialID { get; set; }
        public Burial Burial { get; set; }

       
      
    }
}
