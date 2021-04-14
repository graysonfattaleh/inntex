using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace BurialSite.Models
{
    /// <summary>
    /// The burial location information. Separate from a burial, doesn't include the burial number.
    /// </summary>
    public class BurialLocation
    {
        public BurialLocation()
        {
            Burials = new HashSet<Burial>();
        }
        [Key]
        [Required]
        public int BurialLocationId { get; set; }
        [Required]
        public string? Dig_Site_Name { get; set; }
        public int? N_S_Grid_Site_Upper { get; set; }
        public int? N_S_Grid_Site_Lower { get; set; }
        public int? E_W_Grid_Site_Upper { get; set; }
        public int? E_W_Grid_Site_Lower { get; set; }
        public string? Area { get; set; } = "";

        public virtual ICollection<Burial> Burials { get; set; }

        public virtual ICollection<YearsExcavatedFrom> YearsExcavatedFroms { get; set; }



    }
}
