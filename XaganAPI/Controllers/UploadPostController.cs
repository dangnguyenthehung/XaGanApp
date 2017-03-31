using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaganAPI.Models;
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

        // POST: api/UploadPost
        public void Post([FromBody]PostDetails post)
        {
            //var obj = JsonConvert.DeserializeObject<PostDetails>(value);
            //int count = obj.post_images.Count();
            int count = post.post_images.Count();

            System.Diagnostics.Debug.WriteLine(count.ToString());

            // insert post
            PostModel model = new PostModel();
            model.Insert_PostDetails(post);

            //return count.ToString();
        }
        
    }
}
