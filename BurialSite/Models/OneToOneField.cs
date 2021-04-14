using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurialSite.Models
{
    /// <summary>
    /// The field part of a dynamic field.
    /// Special class that represents the value for one of the dynamic columns that can be added to 
    /// at any time.
    /// </summary>
    public class OneToOneField
    {
        public int OneToOneFieldId { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }

        public virtual ICollection<OneToOneValue> OneToOneValue { get; set; }
    }
}
