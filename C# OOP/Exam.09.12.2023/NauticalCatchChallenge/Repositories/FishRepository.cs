using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    internal class FishRepository : Repository<IFish>
    {

        public override IFish GetModel(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }
    }
}
