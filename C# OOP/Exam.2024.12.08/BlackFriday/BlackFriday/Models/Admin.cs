﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    internal class Admin : User
    {
        public Admin(string userName, string email) : base(userName, email, false)
        {
        }

        public override bool HasDataAccess { get => false; protected set { } }
    }
}
