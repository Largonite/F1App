using System;
using System.Linq;
using System.Linq.Expressions;
using F1App.Domain.Abstract;
using System.Diagnostics;

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

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public bool Save(int id,TEntity entity)
        {
            TEntity e;
            if (id == 0)
            {
                e = _context.Set<TEntity>().Add(entity);

            }else
            {
                e = GetById(id);
                if (e != null)
                {
                    foreach (var prop in entity.GetType().GetProperties())
                    {
                        prop.SetValue(e, prop.GetValue(entity));
                    }
                }
            }
            
            if (e != null)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).Select(t => t);
        }

        public TEntity Delete(int id)
        {
            TEntity e =  GetById(id);
            if (e != null)
            {
                TEntity res = _context.Set<TEntity>().Remove(e);
                try
                {
                    _context.SaveChanges();
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }             
                return res;
            }
            return null;            
        }
    }
}
