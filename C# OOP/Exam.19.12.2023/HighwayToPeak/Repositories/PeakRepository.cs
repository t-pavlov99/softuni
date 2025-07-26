using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    internal class PeakRepository : Repository<IPeak>
    {
        public override IPeak Get(string name)
        {
            return _all.FirstOrDefault(x => x.Name == name);
        }
    }
}
