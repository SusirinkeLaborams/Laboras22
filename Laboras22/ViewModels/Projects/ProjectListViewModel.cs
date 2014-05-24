using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectListViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; private set; }
    }
}
