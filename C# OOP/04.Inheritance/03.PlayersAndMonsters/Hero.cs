﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    internal class Hero
    {
        public string Username { get; set; }
        public int Level { get; set; }

        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public override string ToString()

        {

            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";

        }
    }
}
