using System;
using System.Collections.Generic;

namespace BurialSite.Models
{
    public class FileUrl
    {
        public int FileUrlId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }

        
    }
}
