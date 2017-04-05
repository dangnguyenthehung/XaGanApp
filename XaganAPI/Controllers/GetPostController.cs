using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XaganAPI.Models;
using XaganAPI.Framework;
using Newtonsoft.Json;
using XaganAPI.Object;

namespace XaganAPI.Controllers
{
    public class GetPostController : ApiController
    {
        // GET: api/GetPost
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetPost/5
        public List<PostDetails_Get> Get(long id)
        {
            PostModel model = new PostModel();
            List<PostDetails_Get> listPost = model.Get_PostDetails(id);

            //var jsonObject = JsonConvert.SerializeObject(listPost);

            return listPost;
        }
        
    }
}
