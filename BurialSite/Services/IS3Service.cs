using System;
using System.Threading.Tasks;
using BurialSite.Models;
using Microsoft.AspNetCore.Http;

namespace BurialSite.Services
{
    public interface IS3Service
    {

       /* Task<S3Response>CreateBucketAsync(string bucketName);*/
        Task<string> AddItem(IFormFile file, string readerName);
    };
}
