using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        // YOUR CODE HERE (If needed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasKey(x => new { x.LikerId, x.LikedId });

            modelBuilder.Entity<Match>()
                .HasOne(x => x.Liker)
                .WithMany(x => x.Matches)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.ReceivedMessages)
                .OnDelete(DeleteBehavior.NoAction);
                
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users {  get; set; } 
        public DbSet<Match> Matches {  get; set; } 
        public DbSet<Message> Messages {  get; set; } 
    }
}
