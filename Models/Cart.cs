using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kp2.Models
{
    public class Cart
    {
        public int id { set; get; }
        public int idTV { get; set; }
        public int idUser { set; get; }
        public TV TV { set; get; }
    }
}
