using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kp2.Models
{
    public class Order
    {
        public int id { get; set; }
        public int COId { get; set; }
        public ContOrder CO { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
