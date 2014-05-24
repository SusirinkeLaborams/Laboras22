using Laboras22.Models.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    class FacultyViewModel : ViewModelBase<Faculty, FacultyViewModel>
    {
        #region Settable properties

        public string Name { get { return model.Name; } set { model.Name = value; } }

        public UniversityViewModel University
        {
            get { return university; }
            set
            {
                university = value;
                model.UniversityId = university.Id;
            }
        }

        public LecturerViewModel Dean 
        {
            get { return dean; }
            set
            {
                dean = value;
                model.DeanId = dean.Id;
            }
        }

        public string Address { get { return model.Address; } set { model.Address = value; } }

        #endregion

        #region Read-only properties

        public string UniversityName { get { return University.Name; } }
        public string DeanName { get { return dean.Name; } }

        #endregion

        #region Fields

        private UniversityViewModel university;
        private LecturerViewModel dean;

        #endregion

        protected override async Task RefreshFields()
        {
            university = await UniversityViewModel.Get(model.UniversityId);
            dean = await LecturerViewModel.Get(model.DeanId);
        }
    }
}
