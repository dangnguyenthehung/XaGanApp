namespace XaganAPI.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Xagan2017TestDbContext : DbContext
    {
        public Xagan2017TestDbContext()
            : base("name=Xagan2017TestDbContext")
        {
        }

        public virtual DbSet<Post_Image> Post_Image { get; set; }
        public virtual DbSet<PostDetail> PostDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post_Image>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<PostDetail>()
                .Property(e => e.post_square)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PostDetail>()
                .Property(e => e.post_price)
                .HasPrecision(18, 0);
        }
    }
}
