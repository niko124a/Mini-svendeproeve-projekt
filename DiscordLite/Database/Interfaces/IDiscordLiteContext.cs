using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IDiscordLiteContext : IDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Friend> Friend { get; set; }
        DbSet<FriendRequest> FriendRequest { get; set; }

    }
}
