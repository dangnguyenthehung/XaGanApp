using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XaganAPI.Framework;

namespace XaganAPI.Models
{
    public class PostModel
    {
        Xagan2017TestDbContext context = null;

        public PostModel()
        {
            context = new Xagan2017TestDbContext();
        }

        public void Insert_PostDetails(Object.PostDetails post)
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

                var res = context.Database.ExecuteSqlCommand("Sp_InsertPost @post_type,@post_email,@post_phoneNumber,@post_address,@post_square,@post_price,@post_additonalInfo", sqlParams);

                System.Diagnostics.Debug.WriteLine(res.ToString());
            }
        }
    }
}