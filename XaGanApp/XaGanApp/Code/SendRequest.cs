using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XaGanApp.Object;

namespace XaGanApp.Code
{
    public static class SendRequest
    {

        public static async void Upload_Post(PostDetails post)
        {
            

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dangnguyenthehung.somee.com/XaganAPI/api/UploadPost/");
            //client.BaseAddress = new Uri("http://localhost:64259/api/UploadPost/");

            var jsonObject = JsonConvert.SerializeObject(post);
            System.Diagnostics.Debug.WriteLine(jsonObject);

            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            System.Diagnostics.Debug.WriteLine(content.ToString());


            var result = await client.PostAsync(client.BaseAddress, content);

            System.Diagnostics.Debug.WriteLine("img count = " + result.ToString());

            //var pairs = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("post_type", post.post_type),
            //    new KeyValuePair<string, string>("post_email", post.post_email),
            //    new KeyValuePair<string, string>("post_phoneNumber", post.post_phoneNumber.ToString()),
            //    new KeyValuePair<string, string>("post_address", post.post_address),
            //    new KeyValuePair<string, string>("post_square", post.post_square.ToString()),
            //    new KeyValuePair<string, string>("post_price", post.post_price.ToString()),
            //    new KeyValuePair<string, string>("post_additonalInfo", post.post_additonalInfo),
            //    new KeyValuePair<string, string>("post_images", post.post_images),
            //};

            //var content = new FormUrlEncodedContent(pairs);

            //var response = client.PostAsync("youruri", content).Result;

            //if (response.IsSuccessStatusCode)
            //{


            //}
        }
    }
}
