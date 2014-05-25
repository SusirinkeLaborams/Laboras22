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
            var tmp = ProjectParticipantViewModel.Where(x => x.StudentId == sId);
            var otherTmp = ProjectViewModel.Where(x => x.OwnerId == sId);
            Projects = (await tmp).Select(a => a.Project).Union(await otherTmp);
        }
    }
}
