using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp2.Models;

namespace kp2.ViewModels
{
    public class CM
    {
        public IEnumerable<Cart> Cts { get; set; }
        public IEnumerable<TV> TVs { get; set; }
    }
}
