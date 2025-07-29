using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    internal class Application : IApplication
    {
        private IRepository<IProduct> _products;
        private IRepository<IUser> _users;

        public Application()
        {
            _users = new UserRepository();
            _products = new ProductRepository();
        }

        public IRepository<IProduct> Products => _products;

        public IRepository<IUser> Users => _users;
    }
}
