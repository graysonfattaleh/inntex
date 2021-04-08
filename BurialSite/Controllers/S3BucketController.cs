using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using BurialSite.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BurialSite.Controllers
{
   


    [Produces("application/json")]
    [Route("api/[controller]")]
    public class S3BucketController : Controller
    {
        private readonly IS3Service _service;


        [HttpPost("{bucketName}")]
       /* public async Task<IActionResult> CreateBucket([FromRoute]string bucketName)
        {
            S3Response response = await _service.CreateBucketAsync(bucketName);
            return Ok(response);
        }*/


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
