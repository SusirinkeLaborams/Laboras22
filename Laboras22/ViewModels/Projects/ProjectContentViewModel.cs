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
        public int Project { get { return model.Project; } set { model.Project = value; } }
        public string URL { get { return model.URL; } set { model.URL = value; } }

        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
