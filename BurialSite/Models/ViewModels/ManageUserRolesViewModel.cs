using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurialSite.Models.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public ResearchUser User { get; set; }
        public List<Role> Roles { get; set; }
    }
}
