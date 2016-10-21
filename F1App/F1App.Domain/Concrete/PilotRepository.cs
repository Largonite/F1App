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
        private DbContext context = new DbContext();

        public IEnumerable<Pilot> Pilots
        {
            get
            {
                return context.Pilots;
            }
        }
    }
}
