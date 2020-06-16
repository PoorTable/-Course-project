using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kp2.Models;

namespace kp2.Interfaces
{
    public interface ICart
    {
        AppDBContext Carts { get; }
        IEnumerable<Cart> GetCart { get; }
    }
}
