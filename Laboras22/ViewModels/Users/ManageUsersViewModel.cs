using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Users
{
    class ManageUsersViewModel : NotifyPropertyChangedBase
    {
        private IEnumerable<LecturerViewModel> m_Lecturers;
        private IEnumerable<AdministratorViewModel> m_Administrators;
        private IEnumerable<StudentViewModel> m_Students;
        private IEnumerable<IUserViewModel> m_Users;

        public IEnumerable<LecturerViewModel> Lecturers
        {
            get
            {
                return m_Lecturers;
            }
            set
            {
                m_Lecturers = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<AdministratorViewModel> Administrators
        {
            get
            {
                return m_Administrators;
            }
            set
            {
                m_Administrators = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<StudentViewModel> Students
        {
            get
            {
                return m_Students;
            }
            set
            {
                m_Students = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<IUserViewModel> Users
        {
            get
            {
                return m_Users;
            }
            set
            {
                m_Users = value;
                OnPropertyChanged();
            }
        }



        public async Task LoadUsers()
        {
            var studentTask = StudentViewModel.Enumerate();
            var lecturerTask = LecturerViewModel.Enumerate();
            var adminTask = AdministratorViewModel.Enumerate();
            var students = (await studentTask) as IEnumerable<IUserViewModel>;
            var lecturers = (await lecturerTask) as IEnumerable<IUserViewModel>;
            var admins = (await adminTask) as IEnumerable<IUserViewModel>;

            Students = studentTask.Result;
            Lecturers = lecturerTask.Result;
            Administrators = adminTask.Result;

            m_Users = new List<IUserViewModel>();
            Users = m_Users.Union(students).Union(lecturers).Union(admins);
        }
    }
}
