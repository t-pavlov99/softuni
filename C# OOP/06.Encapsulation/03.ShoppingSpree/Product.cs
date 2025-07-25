﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    internal class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {

            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}