using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    internal abstract class Product : IProduct
    {
        public Product(string productName, double basePrice)
        {
            ProductName = productName;
            BasePrice = basePrice;
            _isSold = false;
        }

        private string _name;
        private double _basePrice;
        private bool _isSold;
        public string ProductName
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name is required.");
                }
                _name = value;
            }
        }

        public double BasePrice
        {
            get { return _basePrice; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be zero or negative.");
                }
                _basePrice = value;
            }
        }

        public abstract double BlackFridayPrice { get; }

        public bool IsSold
        {
            get { return _isSold; }
            private set
            {
                _isSold = false;
            }
        }

        public void ToggleStatus()
        {
            _isSold = !IsSold;
        }

        public void UpdatePrice(double newPriceValue)
        {
            BasePrice = newPriceValue;
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice - BlackFridayPrice):F2}";
        }
    }
}
