//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace F1App.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pilot
    {
        public int PilotId { get; set; }
        public string PilotFName { get; set; }
        public string PilotLName { get; set; }
        public int PilotNumber { get; set; }
        public string PilotAbv { get; set; }
        public string PilotNationality { get; set; }
        public int TeamId { get; set; }
    
        public virtual Team Team { get; set; }
    }
}