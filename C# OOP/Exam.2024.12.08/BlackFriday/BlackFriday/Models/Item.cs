using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    internal class Item : Product
    {
        public Item(string productName, double basePrice) : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice => 0.7 * BasePrice;
    }
}
