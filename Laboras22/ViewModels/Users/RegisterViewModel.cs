using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Laboras22.Models.Assignments;
using Laboras22.Models.Users;
using Laboras22.Views.Windows;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Laboras22.ViewModels.Assignments;

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

        private UniversityViewModel m_University;
        private FacultyViewModel m_Faculty;
        private FacultyDepartmentViewModel m_Department;

        private SecureString m_Password;
        private SecureString m_ConfirmPassword;

        private IEnumerable<UniversityViewModel> m_Universities;
        private IEnumerable<FacultyViewModel> m_Faculties;
        private IEnumerable<FacultyDepartmentViewModel> m_FacultyDepartments;

        public async Task LoadFaculties()
        {
            m_Faculties = await FacultyViewModel.Where(x => m_University.Id == x.UniversityId);
            OnPropertyChanged("Faculties");
        }

        public async Task LoadFacultyDepartments()
        {
            m_FacultyDepartments = await FacultyDepartmentViewModel.Where(x => m_Faculty.Id == x.FacultyId);
            OnPropertyChanged("FacultyDepartments");
        }

        public IEnumerable<UniversityViewModel> Universities
        {
            get 
            {
                return m_Universities; 
            }
            set 
            { 
                m_Universities = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<FacultyViewModel> Faculties
        {
            get
            {
                return m_Faculties;
            }
            set
            {
                m_Faculties = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<FacultyDepartmentViewModel> FacultyDepartments
        {
            get
            {
                return m_FacultyDepartments;
            }
            set
            {
                m_FacultyDepartments = value;
                OnPropertyChanged();
            }
        }

        public RegisterViewModel()
        {
            Universities = new List<UniversityViewModel>();
            Faculties = new List<FacultyViewModel>();
            FacultyDepartments = new List<FacultyDepartmentViewModel>();
        }

        public async Task LoadUniversities()
        {
            Universities = await UniversityViewModel.Enumerate();
        }

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
                return (int)m_UserType;
            }
            set
            {
                m_UserType = (UserTypeEnum)value;
                OnPropertyChanged();
                OnPropertyChanged("AliasVisibility");
                OnPropertyChanged("FacultyVisibility");
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

        public UniversityViewModel University
        {
            get
            {
                return m_University;
            }
            set
            {
                m_University = value;
                OnPropertyChanged();
            }
        }

        public FacultyViewModel Faculty
        {
            get
            {
                return m_Faculty;
            }
            set
            {
                m_Faculty = value;
                OnPropertyChanged();
            }
        }

        public FacultyDepartmentViewModel Department
        {
            get
            {
                return m_Department;
            }
            set
            {
                m_Department = value;
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

        public Visibility FacultyVisibility
        {
            get
            {
                return m_UserType == UserTypeEnum.Lecturer ? Visibility.Visible : Visibility.Collapsed;
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
