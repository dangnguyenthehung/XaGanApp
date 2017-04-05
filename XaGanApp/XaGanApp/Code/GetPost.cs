using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XaGanApp.Object;

namespace XaGanApp.Code
{
    public class GetPost
    {
        public static List<PostDetail> listPost = new List<PostDetail>();
        

        public static async Task<List<PostDetail>> Get_All_Post()
        {
            var client = new HttpClient();
            //client.BaseAddress = new Uri("http://dangnguyenthehung.somee.com/XaganAPI/api/GetPost/0");
            client.BaseAddress = new Uri("http://xaganapitest.gear.host/api/GetPost/0");
            //client.BaseAddress = new Uri("http://localhost:64259/api/GetPost/0");
            var response = await client.GetAsync(client.BaseAddress, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            
            var result = await response.Content.ReadAsStringAsync();

            //System.Diagnostics.Debug.WriteLine(result.ToString());
            List<PostDetail> list = new List<PostDetail>();
            try
            {
                list = JsonConvert.DeserializeObject<List<PostDetail>>(result);
                //listPost = list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return list;
        }
    }
}
