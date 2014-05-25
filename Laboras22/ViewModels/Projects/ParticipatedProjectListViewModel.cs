using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ParticipatedProjectListViewModel : ProjectListViewModel
    {
        private int sId;
        public ParticipatedProjectListViewModel(int sId)
        {
            this.sId = sId;
        }
        public override async Task LoadProjects()
        {
            var tmp = await ProjectParticipantViewModel.Where(x => x.StudentId == sId);
            Projects = tmp.Select(a => a.Project);
        }
    }
}
