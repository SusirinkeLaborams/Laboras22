using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    public class StudentViewModel : ViewModelBase<Student, StudentViewModel>, IUserViewModel
    {
        public string FirstName { get { return model.FirstName; } set { model.FirstName = value; } }
        public string LastName { get { return model.LastName; } set { model.LastName = value; } }
        public string Email { get { return model.Email; } set { model.Email = value; } }
        public string Alias { get { return model.Alias; } set { model.Alias = value; } }

        public string Name { get { return FirstName + " " + LastName; } }
        protected override Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
