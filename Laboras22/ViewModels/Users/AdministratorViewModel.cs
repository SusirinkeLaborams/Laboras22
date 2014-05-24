using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    class AdministratorViewModel : ViewModelBase<Administrator, AdministratorViewModel>, IUserViewModel
    {
        public string FirstName { get { return model.FirstName; } set { model.FirstName = value; } }
        public string LastName { get { return model.LastName; } set { model.LastName = value; } }
        public string Email { get { return model.Email; } set { model.Email = value; } }
        public string Name { get { return FirstName + " " + LastName; } }

        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
