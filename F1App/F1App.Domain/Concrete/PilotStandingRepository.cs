using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;

namespace F1App.Domain.Concrete
{
    public class PilotStandingRepository : IPilotStandingRepository
    {
        private F1AppEntities1 context = new F1AppEntities1();
        public IQueryable<PilotStanding> PilotStandigs
        {
            get
            {
                return from p in context.PilotStandings select p;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
