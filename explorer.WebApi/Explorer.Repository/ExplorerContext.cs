using Explorer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Repository
{
    public class ExplorerContext : DbContext
    {
        public ExplorerContext(DbContextOptions<ExplorerContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentsLocations> CommentsLocations { get; set; }
        public DbSet<UsersLocations> UsersLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentsLocations>().HasKey(CL => new { CL.CommentId, CL.LocationId });

            modelBuilder.Entity<UsersLocations>().HasKey(UL => new { UL.UserId, UL.LocationId });
        }
    }
}