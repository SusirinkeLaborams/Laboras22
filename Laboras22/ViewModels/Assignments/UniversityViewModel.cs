using Laboras22.Models.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    class UniversityViewModel : ViewModelBase<University, UniversityViewModel>
    {
        #region Settable properties

        public string Name { get { return model.UniversityName; } set { model.UniversityName = value; } }
        public string Description { get { return model.Description; } set { model.Description = value; } }
        public int YearFounded { get { return model.YearFounded; } set { model.YearFounded = value; } }

        public LecturerViewModel Rector 
        {
            get { return rector; }
            set
            {
                rector = value;
                model.RectorId = rector.Id;
            }
        }

        #endregion

        #region Read-Only properties

        public string RectorName { get { return Rector.Name; } }

        #endregion

        #region Fields

        private LecturerViewModel rector;

        #endregion

        protected override async Task RefreshFields()
        {
            rector = await LecturerViewModel.Get(model.RectorId);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
