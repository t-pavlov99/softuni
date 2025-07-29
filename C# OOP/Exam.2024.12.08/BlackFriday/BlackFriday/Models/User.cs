using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    internal abstract class User : IUser
    {
        public User(string userName, string email, bool hasDataAccess)
        {
            UserName = userName;
            Email = email;
            HasDataAccess = hasDataAccess;
        }
        private string _username;
        private string _email;
        public string UserName
        {
            get { return _username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username is required.");
                }
                _username = value;
            }
        }

        public abstract bool HasDataAccess { get; protected set; }

        public string Email

        {
            get
            {
                if (HasDataAccess)
                {
                    return _email;
                }
                else
                {
                    return "hidden";
                }
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required.");
                }
                _email = value;
            }
        }

        public override string ToString()
        {
            return $"{UserName} - Status: {GetType().Name}, Contact Info: {Email}";
        }
    }
}
