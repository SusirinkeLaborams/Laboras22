using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboras22.ViewModels.Users
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        private enum UserTypeEnum { Student = 0, Lecturer = 1 }

        private string m_UserName;
        private string m_Email;
        private string m_FirstName;
        private string m_LastName;
        private UserTypeEnum m_UserType;
        private string m_Alias;

        private SecureString m_Password;
        private SecureString m_ConfirmPassword;

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

        public SecureString Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
                OnPropertyChanged();
            }
        }

        public SecureString ConfirmPassword
        {
            get
            {
                return m_ConfirmPassword;
            }
            set
            {
                m_ConfirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return m_FirstName;
            }
            set
            {
                m_FirstName = value;
                OnPropertyChanged();
            }
        }
        
        public string LastName
        {
            get
            {
                return m_LastName;
            }
            set
            {
                m_LastName = value;
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
                OnPropertyChanged("AliasVisibility");
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

        public Visibility AliasVisibility
        {
            get
            {
                return m_UserType == UserTypeEnum.Student ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void Register()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
