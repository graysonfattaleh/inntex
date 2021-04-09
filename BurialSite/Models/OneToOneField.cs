using System;
using System.Collections.Generic;

namespace BurialSite.Models
{
    public class OneToOneField
    {
        public int OneToOneFieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<OneToOneValue> OneToOneValue { get; set; }
    }
}
