using Laboras22.Models.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    public class UniversityViewModel : ViewModelBase<University, UniversityViewModel>
    {
        #region Settable properties

        public string Name { get { return model.Name; } set { model.Name = value; } }
        public string Description { get { return model.Description; } set { model.Description = value; } }
        public int YearFounded { get { return model.YearFounded; } set { model.YearFounded = value; } }

        public UserViewModel Rector 
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

        private UserViewModel rector;

        #endregion

        protected override async Task RefreshFields()
        {
            rector = await UserViewModel.Get(model.RectorId);
        }
    }
}
