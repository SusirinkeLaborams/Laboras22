using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ParticipatedProjectListViewModel : ProjectListViewModel
    {
        public ParticipatedProjectListViewModel(int sId)
        {
            LoadProjects(sId);
        }
        public async void LoadProjects(int studentId)
        {
            var tmp = await ProjectParticipantViewModel.Where(x => x.StudentId == studentId);
            Projects = tmp.Select(a => a.Project);
        }
    }
}
