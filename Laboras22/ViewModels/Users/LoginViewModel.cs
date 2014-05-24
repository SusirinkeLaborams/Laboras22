using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Classes;
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

        public async Task<SessionViewModel> Login(SecureString password)
        {
            var userList = await LoginViewModel.Where(x => UserName == x.UserName);
            if (userList.Count() == 0)
            {
                return null;
            }
            var user = userList.First();
            string hash = PasswordUtils.ComputePassword(password, user.Salt);
            if (hash != user.PasswordHash)
            {
                return null;
            }
            var session = await SessionViewModel.Create();
            session.Time = DateTime.Now;
            session.UserLogin = user;
            session.IP = new WebClient().DownloadString("http://icanhazip.com");

            var student = (await StudentViewModel.Where(x => x.LoginId == user.Id)).FirstOrDefault();
            if (student != null)
            {
                session.UserType = SessionViewModel.UserTypeEnum.Student;
                session.User = student;
                return session;
            }
            var lecturer = (await LecturerViewModel.Where(x => x.LoginId == user.Id)).FirstOrDefault();
            if(lecturer != null)
            {
                session.UserType = SessionViewModel.UserTypeEnum.Lecturer;
                session.User = lecturer;
                return session;
            }
            
            var administrator = (await AdministratorViewModel.Where(x => x.LoginId == user.Id)).FirstOrDefault();
            if(administrator != null)
            {
                session.UserType = SessionViewModel.UserTypeEnum.Administrator;
                session.User = administrator;
                return session;
            }
            throw new NotSupportedException();
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
