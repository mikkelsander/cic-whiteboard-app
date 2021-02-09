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


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Sam",
                AzureActiveDirectoryId = "557ef0be-1b6a-4ce3-ad0e-49473dc086c5",
                UserRole = Enums.UserRole.Moderator
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Bertha",
                AzureActiveDirectoryId = "2c778e64-0b47-4f12-8e83-65c538045750",
                UserRole = Enums.UserRole.User
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 1,
                UserId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title",
                Content = "Cool post content..."
            });


            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 2,
                UserId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 2",
                Content = "Cool post content 2..."
            });


            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 3,
                UserId = 2,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 3",
                Content = "Cool post content 3..."
            });


            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 4,
                UserId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 4",
                Content = "Cool post content 4..."
            });



            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 5,
                UserId = 2,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 5",
                Content = "Cool post content 5..."
            });



            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 6,
                UserId = 2,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 6",
                Content = "Cool post content 6..."
            });


            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 7,
                UserId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 7",
                Content = "Cool post content 7..."
            });



            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 8,
                UserId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 8",
                Content = "Cool post content 8..."
            });



            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 9,
                UserId = 2,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 9",
                Content = "Cool post content 9..."
            });



            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 10,
                UserId = 2,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Title = "Cool Post Title 10",
                Content = "Cool post content 10..."
            });



            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 1,
                UserId = 1,
                PostId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 2,
                UserId = 2,
                PostId = 1,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content 2..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 3,
                UserId = 2,
                PostId = 2,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });


            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 4,
                UserId = 1,
                PostId = 4,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 5,
                UserId = 2,
                PostId = 9,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 6,
                UserId = 2,
                PostId = 4,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 7,
                UserId = 2,
                PostId = 7,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 8,
                UserId = 2,
                PostId = 6,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 9,
                UserId = 1,
                PostId = 8,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 10,
                UserId = 2,
                PostId = 10,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });

            modelBuilder.Entity<UserComment>().HasData(new UserComment
            {
                Id = 11,
                UserId = 1,
                PostId = 10,
                CreatedTime = new System.DateTime(),
                LastModifiedTime = new System.DateTime(),
                Content = "Cool comment content..."
            });


            modelBuilder.Entity<UserReaction>().HasData(new UserReaction
            {
                UserId = 1,
                PostId = 3,
                Type = Enums.ReactionType.Like,
            });

            modelBuilder.Entity<UserReaction>().HasData(new UserReaction
            {
                UserId = 2,
                PostId = 1,
                Type = Enums.ReactionType.Like,
            });

            modelBuilder.Entity<UserReaction>().HasData(new UserReaction
            {
                UserId = 1,
                PostId = 6,
                Type = Enums.ReactionType.Like,
            });

            modelBuilder.Entity<UserReaction>().HasData(new UserReaction
            {
                UserId = 2,
                PostId = 8,
                Type = Enums.ReactionType.Like,
            });

            modelBuilder.Entity<UserReaction>().HasData(new UserReaction
            {
                UserId = 2,
                PostId = 5,
                Type = Enums.ReactionType.Like,
            });
        }
    }




}
