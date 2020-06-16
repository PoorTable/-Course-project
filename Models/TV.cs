using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kp2.Models
{
    public class TV
    {
        //public TV(string mode, ushort pric)
        //{
        //    model = mode;
        //    price = pric;
        //}
        public int id { set; get; }
        public string model { get; set; }
        public ushort price { get; set; }
        public string img { get; set; }
        public string LongDescr { get; set; }
        public string ShortDescr { get; set; }
    }
}
