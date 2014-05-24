using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    class SessionViewModel : ViewModelBase<Sessions, SessionViewModel>
    {
        public enum UserTypeEnum { Student = 0, Lecturer = 1, Administrator = 2 }

        private LoginViewModel m_UserLogin;

        public LoginViewModel UserLogin
        {
            get
            {
                return m_UserLogin;
            }
            set
            {
                m_UserLogin = value;
                model.UserId = value.Id;
            }
        }

        public DateTime Time { get; set; }

        public IUserViewModel User { get; set; }
        public UserTypeEnum UserType { get; set; }





#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998
    }
}
