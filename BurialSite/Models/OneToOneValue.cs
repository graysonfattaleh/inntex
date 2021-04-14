using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurialSite.Models

{
    /// <summary>
    /// Special class that represents the value for one of the dynamic columns that can be added to 
    /// at any time.
    /// </summary>
    public class OneToOneValue
    {
        [Key]
        public int OneToneValueId { get; set; }
        //[Key]
        public int OneToOneFieldId { get; set; }
       // [Key]
        public int BurialId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }
        public virtual OneToOneField OneToOneField { get; set; }
        public virtual Burial Burial { get; set; }
    }
}
