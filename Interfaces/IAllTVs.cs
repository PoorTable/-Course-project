using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp2.Models;

namespace kp2.Interfaces
{
    public interface IAllTVs
    {
        AppDBContext TVs { get; }
        IEnumerable<TV> getFAvTV { get; set; }
        
    }
}
