using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
            int count = post.post_images.Count();

            System.Diagnostics.Debug.WriteLine(count.ToString());

            // insert post
            PostModel model = new PostModel();
            long id = model.Insert_PostDetails(post);

            if (id > 0)
            {

                List<string> Imglist = post.post_images;

                List<PostImageTableType> dataTable = new List<PostImageTableType>();
                foreach(var item in Imglist)
                {
                    var row = new PostImageTableType();
                    row.Post_Id = id;
                    row.Url = item;

                    dataTable.Add(row);
                }
                  
                DataTable table = Code.Convert.ToDataTable(dataTable);

                model.Insert_PostImg(table);
            }
            
            //return count.ToString();
        }
        
    }
}
