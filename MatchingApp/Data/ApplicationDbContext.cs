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

            modelBuilder.Entity<Match>().
                HasOne(m => m.UserLike)
                .WithMany(u => u.UsersLiked)
                .HasForeignKey(u => u.UserLikedId);

            modelBuilder.Entity<Match>().
                HasOne(m => m.UserWhoLiked)
                .WithMany(u => u.UsersWhoLiked)
                .HasForeignKey(u => u.UserWhoLikedId);


            modelBuilder.Entity<Message>().
                HasOne(m => m.Reciever)
                .WithMany(u => u.RecievedMessages)
                .HasForeignKey(u => u.recieverId);

            modelBuilder.Entity<Message>().
                HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(u => u.SenderId);
        }


        public DbSet<User> Users {  get; set; } 
        public DbSet<Match> Matches {  get; set; } 
        public DbSet<Message> Messages {  get; set; } 
    }
}
