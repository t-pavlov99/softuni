﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    internal interface IBuyer
    {
        public int Food {  get; set; }
        public void BuyFood();
    }
}
