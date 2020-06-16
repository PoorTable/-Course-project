using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp2.Models;
using kp2.Interfaces;

namespace kp2.Mocks
{
    public class MockTVs: IAllTVs
    {
        public AppDBContext db;
        public AppDBContext TVs
        {
            get
            {

                return db;
            }
        }
        public IEnumerable<TV> getFAvTV { get; set; }
    }
}
