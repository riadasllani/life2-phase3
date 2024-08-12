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
            base.OnModelCreating(modelBuilder);
            ConfigureMatch(modelBuilder);
            ConfigureMessage(modelBuilder);
        }


        public DbSet<User> Users {  get; set; } 
        public DbSet<Match> Matches {  get; set; } 
        public DbSet<Message> Messages {  get; set; }


     

        private void ConfigureMatch(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(u => u.LikeGiver)
                .WithMany()
                .HasForeignKey(u => u.User1);

            modelBuilder.Entity<Match>()
                .HasOne(u => u.Liked)
                .WithMany()
                .HasForeignKey(u => u.LikedUser);
        }

        private void ConfigureMessage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany()
                .HasForeignKey(u => u.SenderId);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Reciver)
                .WithMany()
                .HasForeignKey(u => u.ReciverId);
        }

    }
}
