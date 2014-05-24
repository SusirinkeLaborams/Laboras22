using Laboras22.Models.Projects;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectParticipantViewModel : ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>
    {
        public StudentViewModel Student { get; private set; }
        protected override async Task RefreshFields()
        {
            Student = await StudentViewModel.Get(model.Student);
        }
        public static new async Task<ProjectParticipantViewModel> Create(ProjectParticipant model = null)
        {
            var created = await ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>.Create(model);
            await created.RefreshFields();
            return created;
        }
    }
}
