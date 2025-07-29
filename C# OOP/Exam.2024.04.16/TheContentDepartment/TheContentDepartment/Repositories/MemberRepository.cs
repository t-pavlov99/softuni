using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    internal class MemberRepository : IRepository<ITeamMember>
    {
        public MemberRepository()
        {
            _models = new List<ITeamMember>();
        }

        private List<ITeamMember> _models;
        public IReadOnlyCollection<ITeamMember> Models { get => _models.AsReadOnly(); }

        public void Add(ITeamMember model)
        {
            _models.Add(model);
        }

        public ITeamMember TakeOne(string modelName)
        {
            if (_models.Any(x => x.Name == modelName))
            {
                return _models.First(x => x.Name == modelName);
            }
            return null;
        }
    }
}
