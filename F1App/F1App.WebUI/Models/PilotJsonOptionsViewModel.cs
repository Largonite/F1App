using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1App.WebUI.Models
{
    public class PilotJsonOptionsViewModel
    {
        public IEnumerable<int> PilotsId { get; set; }
        public IEnumerable<int> PilotsNb { get; set; }
        public IEnumerable<string> PilotsFName { get; set; }
        public IEnumerable<string> PilotsLName { get; set; }
        public IEnumerable<string> PilotsNationality { get; set; }
        public IEnumerable<string> PilotsDOB { get; set; }
        public IEnumerable<string> PilotsAbv { get; set; }
        public IEnumerable<string> PilotsTeam { get; set; }
        public IEnumerable<int> PilotsTeamId { get; set; }
        public IEnumerable<string> PilotsUrl { get; set; }
    }
}