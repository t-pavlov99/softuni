using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    internal class ServiceCampaign : Campaign
    {
        public ServiceCampaign(string brand) : base(brand, 30000.0)
        {
        }
    }
}
