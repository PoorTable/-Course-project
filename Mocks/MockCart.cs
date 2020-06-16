using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp2.Models;
using kp2.Interfaces;

namespace kp2.Mocks
{
    public class MockCart : ICart 
    {
        public AppDBContext db;
        public IEnumerable<Cart> GetCart
        {
            get
            {
                return db.Carts;
            }
        }
        public AppDBContext Carts
        {
            get
            {
                return db;
            }
        }
    }
}
