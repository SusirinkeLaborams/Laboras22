using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    class SessionsViewModel : ViewModelBase<Sessions, SessionsViewModel>
    {
        public LoginViewModel User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
                model.UserId = value.Id;
            }
        }

        private LoginViewModel m_User;


#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998
    }
}
