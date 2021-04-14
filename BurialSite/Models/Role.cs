using System;
using Microsoft.AspNetCore.Identity;

namespace BurialSite.Models
{
    /// <summary>
    /// The role class. This is crucial because it needs to be inherited from so that we can have our own customized identity
    /// that includes first and last names.
    /// </summary>
    public class Role:IdentityRole<int>
    {
        
    }
}
