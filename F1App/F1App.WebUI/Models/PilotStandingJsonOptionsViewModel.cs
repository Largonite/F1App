using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1App.WebUI.Models
{
    public class PilotStandingJsonOptionsViewModel
    {
        public IEnumerable<int> PilotStId { get; set; }
        public IEnumerable<int> PilotStSeason { get; set; }
        public IEnumerable<int> PilotStPosition { get; set; }
        public IEnumerable<int> PilotStPoints { get; set; }
        public IEnumerable<int> PilotStWins { get; set; }
        public IEnumerable<string> PilotStPilotName { get; set; }

    }
}