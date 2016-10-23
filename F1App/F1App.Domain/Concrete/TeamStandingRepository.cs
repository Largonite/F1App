using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;

namespace F1App.Domain.Concrete
{
    public class TeamStandingRepository : ITeamStandingRpository
    {
        private F1AppEntities1 context = new F1AppEntities1();

        public IQueryable<TeamStanding> TeamStandings
        {
            get
            {
                return from t in context.TeamStandings select t;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
