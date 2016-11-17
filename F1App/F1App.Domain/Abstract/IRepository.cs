using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace F1App.Domain.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        bool Save(int id,T entity);
        T Delete(int id);
    }
}
