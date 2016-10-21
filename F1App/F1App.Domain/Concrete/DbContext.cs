using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Entities;

namespace F1App.Domain.Concrete
{
    class DbContext
    {
        F1AppEntities context = new F1AppEntities();
        
        public IQueryable<Pilot> Pilots
        {
            get
            {
                return context.Pilots;
            }
            
        }  

        public IQueryable<Team> Teams
        {
            get
            {
                return context.Teams;
            }
        }
    }
}
