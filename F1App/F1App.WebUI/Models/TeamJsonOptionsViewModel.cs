using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1App.WebUI.Models
{
    public class TeamJsonOptionsViewModel
    {
        public IEnumerable<int> TeamsId { get; set; }
        public IEnumerable<string> TeamsName { get; set; }
        public IEnumerable<string> TeamsNationality { get; set; }
    }
}