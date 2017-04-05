using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XaganAPI.Framework;
using XaganAPI.Object;

namespace XaganAPI.Models
{
    public class PostModel
    {
        //Xagan2017TestDbContext context = null;
        xagantestDBContext context = null;

        public PostModel()
        {
            context = new xagantestDBContext();
        }

        public long Insert_PostDetails(PostDetails post)
        {
            if (post != null)
            {
                object[] sqlParams =
                {
                    new SqlParameter("@post_type", post.post_type),
                    new SqlParameter("@post_email", post.post_email),
                    new SqlParameter("@post_phoneNumber", post.post_phoneNumber),
                    new SqlParameter("@post_address", post.post_address),
                    new SqlParameter("@post_square", post.post_square),
                    new SqlParameter("@post_price", post.post_price),
                    new SqlParameter("@post_additonalInfo", post.post_additonalInfo)
                };

                var res = context.Database.SqlQuery<long>("Sp_InsertPost @post_type,@post_email,@post_phoneNumber,@post_address,@post_square,@post_price,@post_additonalInfo", sqlParams).SingleOrDefault();

                //System.Diagnostics.Debug.WriteLine("Inserted ID is: " + res.ToString());

                return res;
            }
            else
            {
                return 0;
            }
        }

        public void Insert_PostImg(DataTable table)
        {
            var param = new SqlParameter("@PostImageTableType", table);
            param.TypeName = "dbo.PostImageTableType";

            object[] sqlParams =
                {
                    param
                };
            
            var res = context.Database.ExecuteSqlCommand("Sp_InsertPostImage @PostImageTableType", sqlParams);

            //System.Diagnostics.Debug.WriteLine("return is: " + res.ToString());
        }

        public List<PostDetails_Get> Get_PostDetails(long id)
        {
            
                object[] sqlParams =
                {
                    new SqlParameter("@Id", id)
                };

                var res = context.Database.SqlQuery<PostDetails_Get>("Sp_GetAllPost @Id", sqlParams).ToList();

                //System.Diagnostics.Debug.WriteLine("Inserted ID is: " + res.ToString());

            foreach(var item in res)
            {
                if(item.Url == null)
                {
                    item.Url = "http://www.dangnguyenthehung.somee.com/UploadToServer/Uploads/default.png";
                }
            }

                return res;
            
        }
    }
}