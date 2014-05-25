using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    abstract class ProjectListViewModel : NotifyPropertyChangedBase
    {
        private IEnumerable<ProjectViewModel> projects;
        public IEnumerable<ProjectViewModel> Projects 
        {
            get
            {
                return projects;
            }
            protected set
            {
                projects = value;
                OnPropertyChanged();
            }
        }
        public abstract Task LoadProjects();
    }
}
