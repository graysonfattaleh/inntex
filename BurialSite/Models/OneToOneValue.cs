using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurialSite.Models

{
    public class OneToOneValue
    {



        [Key]
        public int OneToneValueId { get; set; }
        //[Key]
        public int OneToOneFieldId { get; set; }
       // [Key]
        public int BurialId { get; set; }

        public string Value { get; set; }
        public virtual OneToOneField OneToOneField { get; set; }
        public virtual Burial Burial { get; set; }


    }
}
