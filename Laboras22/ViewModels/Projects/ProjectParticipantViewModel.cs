using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectParticipantViewModel : ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>
    {
        public int Project { get { return model.Project; } set { model.Project = value; } }
        public int Student { get { return model.Student; } set { model.Student = value; } }

        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
