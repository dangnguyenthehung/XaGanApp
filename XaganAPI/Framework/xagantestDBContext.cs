namespace XaganAPI.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class xagantestDBContext : DbContext
    {
        public xagantestDBContext()
            : base("name=xagantestDBContext")
        {
        }

        public virtual DbSet<Post_Image> Post_Image { get; set; }
        public virtual DbSet<PostDetail> PostDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostDetail>()
                .HasMany(e => e.Post_Image)
                .WithOptional(e => e.PostDetail)
                .HasForeignKey(e => e.Post_Id);
        }
    }
}
