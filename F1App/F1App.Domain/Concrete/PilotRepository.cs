using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;

namespace F1App.Domain.Concrete
{
    public class PilotRepository : IPilotRepository
    {
        private F1AppEntities1 context = new F1AppEntities1();
        public IQueryable<Pilot> Pilots
        {
            get
            {
                return from p in context.Pilots select p;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
