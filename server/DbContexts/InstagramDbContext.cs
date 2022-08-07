using Microsoft.EntityFrameworkCore;
using server.Entites;

namespace server.DbContexts
{
    public class InstagramDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Like> Like { get; set; } = null!;
        public DbSet<FriendShip> Friendships { get; set; } = null!;
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Comment>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Post>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Like>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<FriendShip>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Image>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
            modelBuilder.Entity<User>()
                    .HasIndex(u => u.UserName)
                    .IsUnique();

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {   
                    Id = Guid.NewGuid(),
                    Bio = "I am a software engineer",
                    Email = "amr.atallahh147@gmail.com",
                    Password="AmrAtallah",
                    FirstName= "Amr",
                    LastName= "Atallah",
                    Mobile = "+201145517449",
                    UserName ="amratallah"
                }
                );
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
}
