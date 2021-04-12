using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BurialSite.Models.ViewModels
{
    public class SavePhotoViewModel
    {

        [Required]
        public IFormFile PhotoFile { get; set; }
        public string Type { get; set; }
        public Burial Burial { get; set; }
    
    }
}
