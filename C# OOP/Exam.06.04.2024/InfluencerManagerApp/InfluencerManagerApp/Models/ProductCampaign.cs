using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    internal class ProductCampaign : Campaign
    {
        public ProductCampaign(string brand) : base(brand, 60000.0)
        {
        }
    }
}
