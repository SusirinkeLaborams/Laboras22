using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Laboras22.Models.Users;
using Laboras22.Views.Windows;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Laboras22.ViewModels.Users
{
    public class RegisterViewModel : INotifyPropertyChanged
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

        public async Task<bool> Register()
        {
            var userNameUnique = (await LoginViewModel.Where(x => UserName == x.UserName)).Count() == 0;

            if (!userNameUnique)
            {
                new StyledMessageDialog("User name already exists", "Error registering", MessageBoxButton.OK).ShowDialog();
                return false;
            }

            var userLoginTask = await RegisterUserLogin();
            
            switch (m_UserType)
            {
                case UserTypeEnum.Student:
                    {
                        var student = await StudentViewModel.Create();
                        student.Alias = Alias;
                        student.Email = m_Email;
                        student.FirstName = m_FirstName;
                        student.LastName = m_LastName;
                        student.LoginId = userLoginTask.Id;
                        await student.Insert();
                    }
                    return true;

                case UserTypeEnum.Lecturer:
                    throw new NotImplementedException();

                default:
                    throw new NotSupportedException();
            }   
        }

        private async Task<LoginViewModel> RegisterUserLogin()
        {
            var userLogin = await LoginViewModel.Create();

            userLogin.UserName = UserName;
            userLogin.Salt = GetSalt();

            var saltedPassword = Password.Copy();
            foreach (var saltChar in userLogin.Salt)
            {
                saltedPassword.AppendChar(saltChar);
            }

            saltedPassword.MakeReadOnly();

            var passwordBytes = new byte[saltedPassword.Length * 2];
            var sha = new SHA512Managed();
            var nativeString = IntPtr.Zero;

            try
            {
                nativeString = Marshal.SecureStringToBSTR(saltedPassword);
                Marshal.Copy(nativeString, passwordBytes, 0, passwordBytes.Length);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(nativeString);
            }

            byte[] hashedPassword = sha.ComputeHash(passwordBytes);
            sha.Clear();

            userLogin.PasswordHash = Convert.ToBase64String(hashedPassword);
            await userLogin.Insert();

            return userLogin;
        }

        private const int SaltLength = 16;

        private string GetSalt()
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new byte[SaltLength];

            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
