using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;

namespace F1App.Domain.Concrete
{
    public class TeamRepository : ITeamRepository
    {
        F1AppEntities1 context = new F1AppEntities1();
        public IQueryable<Team> Teams
        {
            get
            {
                return from t in context.Teams select t;
            }
        }
    }
}
