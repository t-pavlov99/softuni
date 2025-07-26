using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    internal class BusinessInfluencer : Influencer
    {
        public BusinessInfluencer(string username, int followers) : base(username, followers, 3.0)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return base.CalculateCampaignPrice(0.15);
        }
    }
}
