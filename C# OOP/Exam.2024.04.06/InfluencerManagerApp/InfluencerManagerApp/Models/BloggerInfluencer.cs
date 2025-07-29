using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    internal class BloggerInfluencer : Influencer
    {
        public BloggerInfluencer(string username, int followers) : base(username, followers, 2.0)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return base.CalculateCampaignPrice(0.2);
        }
    }
}
