using System;
using System.Net;

namespace BurialSite.Models
{
    /// <summary>
    /// Class for s3 response (necessary for s3 functionality)
    /// </summary>
    public class S3Response
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}
