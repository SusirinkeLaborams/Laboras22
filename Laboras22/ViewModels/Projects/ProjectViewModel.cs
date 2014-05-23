using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    public class ProjectViewModel : ViewModelBase<Project, ProjectViewModel>
    {
        public string Name { get { return model.Name; } set { model.Name = value; } }
        public int AssignmentId { get { return model.Assignment; } set { model.Assignment = value; } }
        public int OwnerId { get { return model.Owner; } set { model.Owner = value; } }

        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
