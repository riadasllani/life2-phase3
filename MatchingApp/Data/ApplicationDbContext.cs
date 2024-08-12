﻿using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<User> Users {  get; set; } 
        public DbSet<Match> Matches {  get; set; } 
        public DbSet<Message> Messages {  get; set; } 
    }
}
