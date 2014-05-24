using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ParticipatedProjectListViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; private set; }
        private ParticipatedProjectListViewModel(IEnumerable<ProjectViewModel> projects)
        {
            Projects = projects;
        }
        public static async Task<ParticipatedProjectListViewModel> Create(int studentId)
        {
            var tmp = await ProjectParticipantViewModel.Where(x => x.StudentId == studentId);
            var projects = await ProjectViewModel.Where(p => tmp.Any(a => a.Project.Id == p.Id));
            return new ParticipatedProjectListViewModel(projects);
        }
    }
}
