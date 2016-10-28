using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1App.WebUI.Models
{
    public class TeamStandingJsonOptionViewModel
    {
        public IEnumerable<int> TeamStId { get; set; }
        public IEnumerable<int> TeamStSeason { get; set; }
        public IEnumerable<int> TeamStPosition { get; set; }
        public IEnumerable<int> TeamStPoints { get; set; }
        public IEnumerable<int> TeamStWins { get; set; }
        public IEnumerable<string> TeamStTeamName { get; set; }
    }
}