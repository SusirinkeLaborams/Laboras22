using Laboras22.Models.Projects;
using Laboras22.ViewModels.Assignments;
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
        public string Name { get { return model.ProjectName; } set { model.ProjectName = value; } }
        public string AssignmentName { get { return Assignment.AssignmentName; } }
        public string Task { get { return Assignment.Task; } }
        private AssignmentViewModel assignment;
        public AssignmentViewModel Assignment 
        {
            get
            {
                return assignment;
            }
            set
            {
                assignment = value;
                model.AssignmentId = value.Id;
            }
        }
        private StudentViewModel owner;
        public StudentViewModel Owner 
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                model.OwnerId = value.Id;
            }
        }
        public IEnumerable<ProjectParticipantViewModel> Participants { get; private set; }
        public IEnumerable<ProjectContentViewModel> Contents { get; private set; }
        protected override async Task RefreshFields()
        {
            Owner = await StudentViewModel.Get(model.OwnerId);
            Participants = await ProjectParticipantViewModel.Where(p => p.ProjectId == model.Id);
            Contents = await ProjectContentViewModel.Where(c => c.ProjectId == model.Id);
            Assignment = await AssignmentViewModel.Get(model.AssignmentId);
        }
    }
}
