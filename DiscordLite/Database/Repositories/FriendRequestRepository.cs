using Common.Entities;
using Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class FriendRequestRepository : Repository<FriendRequest>, IFriendRequestRepository
    {
        private readonly IDiscordLiteContext discordLiteContext;
        public FriendRequestRepository(IDiscordLiteContext discordLiteContext) : base(discordLiteContext)
        {
            this.discordLiteContext = discordLiteContext;
        }


    }
}
