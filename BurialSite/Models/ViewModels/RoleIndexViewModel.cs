using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurialSite.Models.ViewModels
{
    public class RoleIndexViewModel
    {   
        public List<Role> Roles { get; set; }
        public List<OneToOneField> Fields { get; set; }
        public Dictionary<ResearchUser, List<string>> UserRolesDict { get; set; }
        public bool IsSuperUser { get; set; }
        public bool IsResearcher { get; set; }
    }
}
