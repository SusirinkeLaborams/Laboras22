using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    public interface IUserViewModel
    {
        int Id { get; }
        int LoginId { get; }
        string FirstName { get; set;  }
        string LastName { get; set; }
        string Email { get; set;  }
        string Name { get; }
    }
}
