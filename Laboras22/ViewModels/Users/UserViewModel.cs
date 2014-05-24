using Laboras22.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    abstract class UserViewModel<ModelType, ViewModelType> : ViewModelBase<ModelType, ViewModelType>, IUserViewModel
        where ModelType : User, new()
        where ViewModelType : ViewModelBase<ModelType, ViewModelType>, new()
    {
        public int LoginId { get { return model.LoginId; } set { model.LoginId = value; } }
        public string FirstName { get { return model.FirstName; } set { model.FirstName = value; } }
        public string LastName { get { return model.LastName; } set { model.LastName = value; } }
        public string Email { get { return model.Email; } set { model.Email = value; } }
        public string Name { get { return FirstName + " " + LastName; } }
    }
}
