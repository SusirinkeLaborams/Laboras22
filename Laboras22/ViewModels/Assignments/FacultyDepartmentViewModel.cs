using Laboras22.Models.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    class FacultyDepartmentViewModel : ViewModelBase<FacultyDepartment, FacultyDepartmentViewModel>
    {
        #region Settable properties

        public string Name { get { return model.Name; } set { model.Name = value; } }
       
        public FacultyViewModel Faculty 
        {
            get { return faculty; }
            set
            {
                faculty = value;
                model.FacultyId = faculty.Id;
            }
        }

        public LecturerViewModel Head 
        {
            get { return head; }
            set
            {
                head = value;
                model.HeadId = head.Id;
            }
        }
        
        public string Description { get { return model.Description; } set { model.Description = value; } }

        #endregion

        #region Read-Only properties

        public string FacultyName { get { return Faculty.Name; } }
        public string HeadName { get { return Head.Name; } }

        #endregion

        #region Fields

        private FacultyViewModel faculty;
        private LecturerViewModel head;

        #endregion

        protected override async Task RefreshFields()
        {
            faculty = await FacultyViewModel.Get(model.FacultyId);
            head = await LecturerViewModel.Get(model.HeadId);
        }
    }
}
