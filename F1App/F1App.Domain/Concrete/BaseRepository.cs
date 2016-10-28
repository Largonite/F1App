using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;

namespace F1App.Domain.Concrete
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly F1AppEntities1 _context;
        public BaseRepository(F1AppEntities1 context)
        {
            this._context = context;
        }

        public IQueryable<TEntity> All()
        {
            return _context.Set<TEntity>().Select(t => t); 
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).Select(t => t);
        }
        
    }
}
