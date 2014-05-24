using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    class StudentViewModel : UserViewModel<Student, StudentViewModel>
    {
        public string Alias { get { return model.Alias; } set { model.Alias = value; } }

#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998
    }
}
