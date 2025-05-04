using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    internal class Pokemon
    {
        private string _name;
        private string _element;
        private int _health;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public string Element
        {
            get { return _element; }
            set { _element = value; }
        }


    }
}
