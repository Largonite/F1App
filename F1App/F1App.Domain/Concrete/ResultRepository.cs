using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;

namespace F1App.Domain.Concrete
{
    public class ResultRepository : IResultRepository
    {
        private F1AppEntities1 context = new F1AppEntities1();
        public IQueryable<Result> Results
        {
            get
            {
                return from r in context.Results select r;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
