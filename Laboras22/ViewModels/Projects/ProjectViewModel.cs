using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectViewModel : ViewModelBase<Project, ProjectViewModel>
    {
        public string Name { get { return model.Name; } set { model.Name = value; } }
        public int Assignment { get { return model.Assignment; } set { model.Assignment = value; } }
        public int Owner { get { return model.Owner; } set { model.Owner = value; } }
        public List<ProjectParticipantViewModel> Participants { get; set; }
        public List<ProjectContentViewModel> Contents { get; set; }
        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
