using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    class AdministratorViewModel : UserViewModel<Administrator, AdministratorViewModel>
    {
#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998
    }
}
