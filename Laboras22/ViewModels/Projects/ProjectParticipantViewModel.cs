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
        public string Name { get { return Student.Name; } }
        private StudentViewModel student;
        public StudentViewModel Student 
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                model.StudentId = value.Id;
            }
        }
        private ProjectViewModel project;
        public ProjectViewModel Project 
        {
            get
            {
                return project;
            }
            set
            {
                project = value;
                model.ProjectId = value.Id;
            }
        }
        protected override async Task RefreshFields()
        {
            student = await StudentViewModel.Get(model.StudentId);
            project = await ProjectViewModel.Get(model.ProjectId);
        }
    }
}
