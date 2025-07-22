using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    internal class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                    throw new Exception("A name should not be empty.");
                name = value;
            }
        }

        private int Endurance
        {
            get { return endurance; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Endurance should be between 0 and 100.");
                endurance = value;
            }
        }

        private int Sprint
        {
            get { return sprint; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Spring should be between 0 and 100.");
                sprint = value;
            }
        }

        private int Dribble
        {
            get { return dribble; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Dribble should be between 0 and 100.");
                dribble = value;
            }
        }

        private int Passing
        {
            get { return passing; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Passing should be between 0 and 100.");
                passing = value;
            }
        }

        private int Shooting
        {
            get { return shooting; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Shooting should be between 0 and 100.");
                shooting = value;
            }
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public decimal Skill
        {
            get => 0.2m * (endurance + sprint + dribble + passing + shooting);
        }
    }
}
