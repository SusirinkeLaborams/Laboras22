using Laboras22.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    public class UserViewModel : ViewModelBase<User, UserViewModel>
    {
        public string FirstName { get { return model.FirstName; } set { model.FirstName = value; } }
        public string LastName { get { return model.LastName; } set { model.LastName = value; } }
        public string Email { get { return model.Email; } set { model.Email = value; } }
        public UserType UserType { get { return model.UserType; } set { model.UserType = value; } }

        public string Name { get { return FirstName + " " + LastName; } }

        protected override void RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
