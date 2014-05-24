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
        public ProjectViewModel Project { get; private set; }
        protected override async Task RefreshFields()
        {
            Student = await StudentViewModel.Get(model.StudentId);
            Project = await ProjectViewModel.Get(model.ProjectId);
        }
    }
}
