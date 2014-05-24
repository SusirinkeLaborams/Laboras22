using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    interface IUserViewModel
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Name { get; }
    }
}
