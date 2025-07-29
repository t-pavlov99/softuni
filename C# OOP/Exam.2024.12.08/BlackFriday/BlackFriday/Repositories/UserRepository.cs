using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    internal class UserRepository : IRepository<IUser>
    {
        private List<IUser> _users;

        public UserRepository()
        {
            _users = new List<IUser>();
        }

        public IReadOnlyCollection<IUser> Models => _users.AsReadOnly();

        public void AddNew(IUser model)
        {
            _users.Add(model);
        }

        public bool Exists(string name)
        {
            return _users.Any(x => x.UserName == name);
        }

        public IUser GetByName(string name)
        {
            return _users.FirstOrDefault(x => x.UserName == name);
        }
    }
}
