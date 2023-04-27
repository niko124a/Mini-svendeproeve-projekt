using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        void Insert(Entity entity);

        IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate = null);

        Entity Get(params object[] primaryKeyValues);

        void Update(Entity entity);

        void Delete(Entity entity);
    }
}
