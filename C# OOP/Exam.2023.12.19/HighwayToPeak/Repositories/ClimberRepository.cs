using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    internal class ClimberRepository : Repository<IClimber>
    {
        public override IClimber Get(string name)
        {
            return _all.FirstOrDefault(x => x.Name == name);
        }
    }
}
