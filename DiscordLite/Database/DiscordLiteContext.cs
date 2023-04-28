using Common.Entities;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DiscordLiteContext : DbContext, IDiscordLiteContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DiscordLite;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends);
        }

        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;

        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;

        public int ExecuteSqlCommand(string sql, params object[] parameters) => Database.ExecuteSqlRaw(sql, parameters);
    }
}
