using Laboras22.Models.Projects;
using Laboras22.ViewModels.Users;
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
        public UserViewModel Owner { get; private set; }
        public IEnumerable<ProjectParticipantViewModel> Participants { get; set; }
        public IEnumerable<ProjectContentViewModel> Contents { get; set; }
        protected override async Task RefreshFields()
        {
            Owner = await UserViewModel.Get(model.Owner);
            Participants = await ProjectParticipantViewModel.Where(p => p.Project == model.Id);
            Contents = await ProjectContentViewModel.Where(c => c.Project == model.Id);
        }
    }
}
