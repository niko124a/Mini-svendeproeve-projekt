using Common.Entities;
using Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        private readonly IDiscordLiteContext discordLiteContext;
        public FriendRepository(IDiscordLiteContext discordLiteContext) : base(discordLiteContext)
        {
            this.discordLiteContext = discordLiteContext;
        }


    }
}
