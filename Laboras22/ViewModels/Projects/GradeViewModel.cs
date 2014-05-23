using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class GradeViewModel : ViewModelBase<Grade, GradeViewModel>
    {
        public int Participant { get { return model.Participant; } set { model.Participant = value; } }

        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
