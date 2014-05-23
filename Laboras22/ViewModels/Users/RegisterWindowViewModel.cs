using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    class RegisterWindowViewModel : INotifyPropertyChanged
    {
        private enum UserTypeEnum { Lecturer = 0, Student = 1 }

        private string m_UserName;
        private string m_Password;
        private string m_Email;
        private UserTypeEnum m_UserType;
        private string m_Alias;


        public string UserName
        {
            get
            {
                return m_UserName;
            }
            set
            {
                m_UserName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
                OnPropertyChanged();
            }
        }

        public int UserType
        {
            get
            {
                return (int) m_UserType;
            }
            set
            {
                m_UserType = (UserTypeEnum) value;
                OnPropertyChanged();
            }
        }

        public string Alias
        {
            get
            {
                return m_Alias;
            }
            set
            {
                m_Alias = value;
                OnPropertyChanged();
            }
        }

        public bool AliasVisibility
        {
            get
            {
                return m_UserType == UserTypeEnum.Student;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void Register(string password)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
