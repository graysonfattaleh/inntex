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
        public List<ResearchUser> Users { get; set; }
    }
}
