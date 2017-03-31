namespace XaganAPI.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostDetail
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string post_type { get; set; }

        [Required]
        [StringLength(200)]
        public string post_email { get; set; }

        public long post_phoneNumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string post_address { get; set; }

        public decimal post_square { get; set; }

        public decimal post_price { get; set; }

        [Required]
        [StringLength(2000)]
        public string post_additonalInfo { get; set; }
    }
}
