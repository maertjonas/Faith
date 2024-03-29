﻿using Domain.Posts;
using Domain.Comments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Service.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                    .HasMany( s => s.Comments)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>()
                    .HasMany( s => s.Juniors)
                    .WithOne()
                    //Change cascade
                    .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}


