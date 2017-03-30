using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaganAPI.Object;

namespace XaganAPI.Controllers
{
    public class UploadPostController : ApiController
    {
        // GET: api/UploadPost
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UploadPost/5
       
        public string Get(string post)
        {
            //var obj = JsonConvert.DeserializeObject<PostDetails>(post);
            //int count = obj.post_images.Count();

            return "OK";
        }

        // POST: api/UploadPost
        public void Post([FromBody]PostDetails value)
        {
            //var obj = JsonConvert.DeserializeObject<PostDetails>(value);
            //int count = obj.post_images.Count();
            int count = value.post_images.Count();
            //return count.ToString();
        }

        // PUT: api/UploadPost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UploadPost/5
        public void Delete(int id)
        {
        }
    }
}
