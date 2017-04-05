namespace XaganAPI.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post_Image
    {
        public long Id { get; set; }

        public long? Post_Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Url { get; set; }

        public virtual PostDetail PostDetail { get; set; }
    }
}
