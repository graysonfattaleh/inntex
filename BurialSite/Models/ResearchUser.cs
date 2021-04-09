using System;
using Microsoft.AspNetCore.Identity;

namespace BurialSite.Models
{
    public class ResearchUser : IdentityUser<int>
    {
       public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
