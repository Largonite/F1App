using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1App.Domain.Entities
{
    public class Pilot
    {
        public int PilotId { get; set; }
        public string PilotFName { get; set; }
        public string PilotLName { get; set; }
        public int PilotNumber { get; set; }
        public string PilotAbv { get; set; }
        public string PilotNationality { get; set; }
        public int TeamId { get; set; }
    }
}
