using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    internal class Client : User
    {
        private Dictionary<string, bool> _purchases;
        public Client(string userName, string email) : base(userName, email, true)
        {
            _purchases = new Dictionary<string, bool>();
        }

        public override bool HasDataAccess { get => true; protected set { } }

        public IReadOnlyDictionary<string, bool> Purchases => _purchases;

        public void PurchaseProduct(string productName, bool blackFridayFlag)
        {
            _purchases.Add(productName, blackFridayFlag);
        }
    }
}
