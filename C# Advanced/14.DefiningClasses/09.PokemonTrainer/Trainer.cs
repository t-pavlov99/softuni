using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    internal class Trainer
    {
        private string _name;

        private int _badgeCount;

        private List<Pokemon> _pokemons = new List<Pokemon>();
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }
        public int BadgeCount
        {
            get { return _badgeCount; }
            set { this._badgeCount = value; }
        }
        public List<Pokemon> Pokemons
        {
            get
            { return _pokemons; }
            set
            { this._pokemons = value; }
        }
    }
}
