using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    internal class CampaignRepository : Repository<ICampaign>
    {
        public override ICampaign FindByName(string brand)
        {
            return _models.FirstOrDefault(x => x.Brand == brand);
        }
    }
}
