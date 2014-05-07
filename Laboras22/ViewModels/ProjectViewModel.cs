using Laboras22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels
{
    public class ProjectViewModel : ViewModelBase<Project, ProjectViewModel>
    {
        public string Name { get { return model.Name; } set { model.Name = value; } }
        public int AssignmentId { get { return model.AssignmentId; } set { model.AssignmentId = value; } }
        public int OwnerId { get { return model.OwnerId; } set { model.OwnerId = value; } }
    }
}
