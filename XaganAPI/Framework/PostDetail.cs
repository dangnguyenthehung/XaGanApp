namespace XaganAPI.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostDetail()
        {
            Post_Image = new HashSet<Post_Image>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string post_type { get; set; }

        [Required]
        [StringLength(200)]
        public string post_email { get; set; }

        public long? post_phoneNumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string post_address { get; set; }

        public decimal? post_square { get; set; }

        public decimal? post_price { get; set; }

        [Required]
        [StringLength(2000)]
        public string post_additonalInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post_Image> Post_Image { get; set; }
    }
}
