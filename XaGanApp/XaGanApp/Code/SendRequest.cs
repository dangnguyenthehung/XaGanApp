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
            //client.BaseAddress = new Uri("http://dangnguyenthehung.somee.com/XaganAPI/api/UploadPost/");
            //client.BaseAddress = new Uri("http://localhost:64259/api/UploadPost/");
            client.BaseAddress = new Uri("http://xaganapitest.gear.host/api/UploadPost/");

            var jsonObject = JsonConvert.SerializeObject(post);
            System.Diagnostics.Debug.WriteLine(jsonObject);

            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            System.Diagnostics.Debug.WriteLine(content.ToString());


            var result = await client.PostAsync(client.BaseAddress, content);

            System.Diagnostics.Debug.WriteLine("result: " + result.ToString());
            
        }
    }
}
