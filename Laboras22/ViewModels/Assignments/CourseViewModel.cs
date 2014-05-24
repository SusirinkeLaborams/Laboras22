using Laboras22.Models.Assignments;
using Laboras22.ViewModels;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    public class CourseViewModel : ViewModelBase<Course, CourseViewModel>
    {
        #region Settable properties

        public string Name { get { return model.Name; } set { model.Name = value; } }

        public FacultyDepartmentViewModel FacultyDepartment
        {
            get { return facultyDepartment; }
            set
            {
                facultyDepartment = value;
                model.FacultyDepartmentId = facultyDepartment.Id;
            }
        }

        public LecturerViewModel Owner
        {
            get { return owner; }
            set
            {
                owner = value;
                model.OwnerId = owner.Id;
            }
        }

        public int SchoolYear { get { return model.SchoolYear; } set { model.SchoolYear = value; } }

        #endregion

        #region Read-Only properties

        public string FacultyDepartmentName { get { return FacultyDepartment.Name; } }
        public string OwnerName { get { return Owner.Name; } }

        #endregion

        #region Fields

        private FacultyDepartmentViewModel facultyDepartment;
        private LecturerViewModel owner;

        #endregion

        protected override async Task RefreshFields()
        {
            facultyDepartment = await FacultyDepartmentViewModel.Get(model.FacultyDepartmentId);
            owner = await LecturerViewModel.Get(model.OwnerId);
        }
    }
}
