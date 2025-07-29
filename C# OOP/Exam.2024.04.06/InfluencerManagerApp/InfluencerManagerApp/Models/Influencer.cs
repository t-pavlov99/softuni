using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    internal abstract class Influencer : IInfluencer
    {
        protected Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            Income = 0;
            _participations = new List<string>();
        }

        private string _username;
        private int _followers;
        private double _engagementRate;
        private double _income;
        private List<string> _participations;
        public string Username
        {
            get => _username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                _username = value;
            }
        }

        public int Followers
        {
            get => _followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                _followers = value;
            }
        }

        public double EngagementRate { get => _engagementRate; private set => _engagementRate = value; }

        public double Income { get => _income; private set => _income = value; }

        public IReadOnlyCollection<string> Participations { get => _participations.AsReadOnly(); }

        public abstract int CalculateCampaignPrice();

        protected int CalculateCampaignPrice(double factor)
        {
            return (int)(Followers * EngagementRate * factor);
        }

        public void EarnFee(double amount)
        {
            Income += amount;
        }

        public void EndParticipation(string brand)
        {
            _participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            _participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
