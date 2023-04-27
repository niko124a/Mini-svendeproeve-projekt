using Common.Entities;
using Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDiscordLiteContext discordLiteContext;
        public UserRepository(IDiscordLiteContext discordLiteContext) : base(discordLiteContext)
        {
            this.discordLiteContext = discordLiteContext;
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                User dbUser = discordLiteContext.User
                .Where(user => user.Username == username)
                .SingleOrDefault();

                return dbUser;
            }
            catch (Exception exception)
            {

                throw;
            }


        }
    }
}
