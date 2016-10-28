using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1App.WebUI.Models
{
    public class ResultJsonOptionViewModel
    {
        public IEnumerable<int> ResultsId { get; set; }
        public IEnumerable<string> ResultsRaceName { get; set; }
        public IEnumerable<int> ResultsPosition { get; set; }
        public IEnumerable<int> ResultsPoints { get; set; }
        public IEnumerable<int> ResultsGrid { get; set; }
        public IEnumerable<string> ResultsStatus { get; set; }
        public IEnumerable<string> ResultsPilotName { get; set; }
    }
}