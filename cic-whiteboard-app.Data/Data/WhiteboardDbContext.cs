using CIC.WhiteboardApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CIC.WhiteboardApp.Data.Data
{
    public class WhiteboardDbContext : DbContext
    {
        public WhiteboardDbContext(DbContextOptions<WhiteboardDbContext> options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserReaction> UserReactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserReaction>()
              .HasKey(r => new { r.PostId, r.UserId });

            //modelBuilder.Entity<UserReaction>()
            //  .HasOne(r => r.Post)
            //  .WithMany(p => p.Reactions)
            //  .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<UserReaction>()
            //  .HasOne(r => r.User)
            //  .WithMany(u => u.Reactions)
            //  .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserComment>()
              .HasOne(c => c.Post)
              .WithMany(p => p.Comments)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserComment>()
              .HasOne(c => c.User)
              .WithMany(u => u.Comments)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }




}
