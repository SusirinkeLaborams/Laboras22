using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class AllProjectListViewModel : ProjectListViewModel
    {
        public AllProjectListViewModel()
        {
        }
        public override async Task LoadProjects()
        {
            Projects = await ProjectViewModel.Enumerate();
        }
    }
}
