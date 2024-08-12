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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany<Message>();

            modelBuilder.Entity<Message>()
                .HasMany<User>();
        }


        public DbSet<User> Users {  get; set; } 
        public DbSet<Match> Matches {  get; set; } 
        public DbSet<Message> Messages {  get; set; } 
    }
}
