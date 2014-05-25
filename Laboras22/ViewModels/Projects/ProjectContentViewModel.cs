using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectContentViewModel : ViewModelBase<ProjectContent, ProjectContentViewModel>
    {
        public string URL { get { return model.URL; } set { model.URL = value; } }
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
            project = await ProjectViewModel.Get(model.ProjectId);
        }
    }
}
