using System;
using Microsoft.AspNetCore.Http;

namespace BurialSite.Models
{
    /// <summary>
    /// For storing information about our s3 bucket information
    /// </summary>
    public class PhotoRecord
    {
        public int PhotRecordId { get; set; }
        public IFormFile PhotoFile { get; set; }
        public string PhotoUrl {get;set;}
        public string Type { get; set; }
    }
}
