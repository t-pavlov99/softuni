using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    internal class InfluencerRepository : Repository<IInfluencer>
    {
        public override IInfluencer FindByName(string name)
        {
            return _models.FirstOrDefault(x => x.Username == name);
        }
    }
}
