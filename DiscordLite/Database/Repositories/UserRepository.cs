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
                return discordLiteContext.User
                .Where(user => user.Username == username)
                .SingleOrDefault();
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return discordLiteContext.User
                    .Where(user => user.Id == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
