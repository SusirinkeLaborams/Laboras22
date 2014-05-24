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

#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998
    }
}
