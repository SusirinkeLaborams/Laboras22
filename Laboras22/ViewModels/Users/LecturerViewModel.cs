using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;
using Laboras22.ViewModels.Assignments;

namespace Laboras22.ViewModels.Users
{
    class LecturerViewModel : UserViewModel<Lecturer, LecturerViewModel>
    {
        public FacultyDepartmentViewModel FacultyDepartment
        {
            get
            {
                return m_FacultyDepartmentViewModel;
            }
            set
            {
                model.FacultyDepartmentId = value.Id;
                m_FacultyDepartmentViewModel = value;
            }
        }

        public string FacultyDepartmentName { get { return FacultyDepartment.Name; } }

        private FacultyDepartmentViewModel m_FacultyDepartmentViewModel;

        protected override async Task RefreshFields()
        {
            FacultyDepartment = await FacultyDepartmentViewModel.Get(model.FacultyDepartmentId);
        }
    }
}
