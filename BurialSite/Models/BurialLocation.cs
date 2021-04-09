using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace BurialSite.Models
{
    public class BurialLocation
    {
        [Key]
        [Required]
        public int BurLocID { get; set; }
        [Required]
        public int BurialID { get; set; }
        [Required]
        public string? Dig_Site_Name { get; set; }
        public int? N_S_Grid_Site_Upper { get; set; }
        public int? N_S_Grid_Site_Lower { get; set; }
        public int? E_W_Grid_Site_Upper { get; set; }
        public int? E_W_Grid_Site_Lower { get; set; }
        public string? Area { get; set; } = "";







    }
}
