﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XaGanApp.Object
{
    public class PostDetails
    {
        public string post_type { get; set; }

        public string post_email { get; set; }

        public int post_phoneNumber { get; set; }

        public string post_address { get; set; }

        public double post_square { get; set; }

        public double post_price { get; set; }

        public string post_additonalInfo { get; set; }

        public List<string> post_images { get; set; }
    }
}