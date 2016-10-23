using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1App.Domain.Abstract
{
    public interface IResultRepository
    {
        IQueryable<Result> Results { get; set; }
    }
}
