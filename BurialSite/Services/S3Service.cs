using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using BurialSite.Models;
using Microsoft.AspNetCore.Http;
using static BurialSite.Services.S3Service;

namespace BurialSite.Services
{
    /// <summary>
    /// This is our service for connecting to and using S3. 
    /// </summary>
    public class S3Service : IS3Service
    {
        //private readonly IAmazonS3 _client;
        private readonly AmazonS3Client s3Client;
        private const string BUCKET_NAME = "arn:aws:s3:us-west-2:249897624530:accesspoint/readwriteinternet";
        private const string FOLDER_NAME = "BurialPhotos";
        private const double DURATION = 24;

        public S3Service()
        {
            //s3Client = new AmazonS3Client(RegionEndpoint.USWest2);
            var amazonS3Config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USWest2
            };
            //Test credentials, will be put in environment later. These are only able to access the s3 bucket
           var credentials = new BasicAWSCredentials("AKIATULYPEPJKXC2YSWS", "HyHqKlkiyajtPJjRRmEbnsUZeklrdYNJNna8KDYP");
           AmazonS3Client s3clientGuy = new AmazonS3Client(credentials,amazonS3Config);
            s3Client = s3clientGuy;
        }

        //variables to add item
      
       

        public async Task<string> AddItem(IFormFile file, string burialName, string photoType)
        {

            

            // implementation for S3 bucket
            string fileName = file.FileName;
            string objectKey = $"{FOLDER_NAME}/{burialName}/{photoType}/{fileName}";
            // string objectKey = $"{FOLDER_NAME}/{readerName}/{fileName}";

            using (Stream fileToUpload = file.OpenReadStream())
            {
                var putObjectRequest = new PutObjectRequest();
                putObjectRequest.BucketName = BUCKET_NAME;
                putObjectRequest.Key = objectKey;
                putObjectRequest.InputStream = fileToUpload;
                putObjectRequest.ContentType = file.ContentType;

                Console.WriteLine($" \n \n THIS IS THE OBJECT KEY :::{objectKey} \n \n");

                var response = await s3Client.PutObjectAsync(putObjectRequest);

                return GeneratePreSignedURL(objectKey);
            }

        }

        // get url thing
        private string GeneratePreSignedURL(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BUCKET_NAME,
                Key = objectKey,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(DURATION)
            };

            string url = s3Client.GetPreSignedURL(request);

            Console.WriteLine(url);
            return url;
        }

    }
}
