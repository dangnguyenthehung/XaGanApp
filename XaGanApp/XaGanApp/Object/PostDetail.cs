using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XaGanApp.Object
{
    public class PostDetail
    {
        public long Id { get; set; }

        public string post_type { get; set; }

        public string post_email { get; set; }

        public long post_phoneNumber { get; set; }

        public string post_address { get; set; }

        public decimal post_square { get; set; }

        public decimal post_price { get; set; }

        public string post_additonalInfo { get; set; }

    }
}
