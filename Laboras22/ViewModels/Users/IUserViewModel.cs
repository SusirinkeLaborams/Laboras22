using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    interface IUserViewModel
    {
        public int LoginId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Name { get; }
    }
}
