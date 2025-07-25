using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    internal abstract class Manager : Contracts.IManager
    {
        protected Manager(string name, double ranking)
        {
            Name = name;
            Ranking = ranking;
        }

        private string name;
        private double ranking;
        
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.ManagerNameNull);
                }
                name = value;
            }
        }

        public double Ranking
        {
            get => ranking;
            protected set => ranking = value;
        }

        public virtual void RankingUpdate(double updateValue)
        {
            Ranking += updateValue;
            Ranking = Math.Max(0, Ranking);
            Ranking = Math.Min(100, Ranking);
        }

        public override string ToString()
        {
            return $"{Name} - {GetType().Name} (Ranking: {Ranking:f2})";
        }
    }
}
