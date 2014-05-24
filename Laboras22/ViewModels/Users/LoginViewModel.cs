using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;

namespace Laboras22.ViewModels.Users
{
    class LoginViewModel : ViewModelBase<UserLogin, LoginViewModel>, INotifyPropertyChanged
    {
        public string UserName
        {
            get
            {
                return model.UserName;
            }
            set
            {
                model.UserName = value;
                OnPropertyChanged();
            }
        }

        public string PasswordHash
        {
            get
            {
                return model.PasswordHash;
            }
            set
            {
                model.PasswordHash = value;
                OnPropertyChanged();
            }
        }

        public string Salt
        {
            get
            {
                return model.Salt;
            }
            set
            {
                model.Salt = value;
                OnPropertyChanged();
            }
        }

        public string OldPasswordHash
        {
            get
            {
                return model.OldPasswordHash;
            }
            set
            {
                model.OldPasswordHash = value;
                OnPropertyChanged();
            }
        }

#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void Login(string password)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
