using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Models.Users;
using Laboras22.ViewModels.Assignments;

namespace Laboras22.ViewModels.Users
{
    public class LecturerViewModel : ViewModelBase<Lecturer, LecturerViewModel>, IUserViewModel
    {

        public string FirstName { get { return model.FirstName; } set { model.FirstName = value; } }
        public string LastName { get { return model.LastName; } set { model.LastName = value; } }
        public string Email { get { return model.Email; } set { model.Email = value; } }
        public FacultyDepartmentViewModel FacultyDepartment
        {
            get
            {
                return m_FacultyDepartmentViewModel;
            }
            set
            {
                model.FacultyDepartment = value.Id;
                m_FacultyDepartmentViewModel = value;
            }
        }
        public string FacultyDepartmentName { get { return FacultyDepartment.Name; } }
        public string Name { get { return FirstName + " " + LastName; } }

        FacultyDepartmentViewModel m_FacultyDepartmentViewModel;

        protected override async Task RefreshFields()
        {
            FacultyDepartment = await FacultyDepartmentViewModel.Get(model.FacultyDepartment);
        }
    }
}
