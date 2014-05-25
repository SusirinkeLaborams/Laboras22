using Laboras22.Models.Projects;
using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectViewModel : ViewModelBase<Project, ProjectViewModel>
    {
        public string Name { get { return model.ProjectName; } set { model.ProjectName = value; OnPropertyChanged(); } }
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
        private ObservableCollection<ProjectContentViewModel> contents;
        public ObservableCollection<ProjectContentViewModel> Contents 
        {
            get
            {
                return contents;
            }
            private set
            {
                contents = value;
                OnPropertyChanged();
            }
        }
        public async Task AddContent()
        {
            var content = await ProjectContentViewModel.Create();
            content.Project = this;
            Contents.Add(content);
            OnPropertyChanged("Contents");
        }
        public override async Task Update()
        {
            var lst = new List<Task>();
            lst.Add(base.Update());
            foreach(var c in Contents)
            {
                if (String.IsNullOrEmpty(c.URL))
                {
                    if (c.Id != 0)
                        lst.Add(c.Delete());
                    continue;
                }
                if (c.Id == 0)
                    lst.Add(c.Insert());
                else
                    lst.Add(c.Update());
            }
            foreach (var t in lst)
                await t;
            OnPropertyChanged("Contents");
        }
        protected override async Task RefreshFields()
        {
            Owner = await StudentViewModel.Get(model.OwnerId);
            Participants = await ProjectParticipantViewModel.Where(p => p.ProjectId == model.Id);
            Contents = new ObservableCollection<ProjectContentViewModel>(await ProjectContentViewModel.Where(c => c.ProjectId == model.Id));
            Assignment = await AssignmentViewModel.Get(model.AssignmentId);
        }
    }
}
