using System;
using System.Collections.Generic;
using F1App.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1App.Domain.Abstract
{
    public interface IPilotRepository
    {
        IEnumerable<Pilot> Pilots { get; }
    }
}
