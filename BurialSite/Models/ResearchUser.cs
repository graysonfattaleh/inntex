using System;
using Microsoft.AspNetCore.Identity;

namespace BurialSite.Models
{
    /// <summary>
    /// The overloaded identity user, includes a first and last name.
    /// </summary>
    public class ResearchUser : IdentityUser<int>
    {
       public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
