using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;

namespace F1App.Domain.Concrete
{
    class TeamRepository : ITeamRepository
    {
        private DbContext context = new DbContext();
        public IEnumerable<Team> Teams
        {
            get
            {
                return context.Teams;
            }
        }
    }
}
