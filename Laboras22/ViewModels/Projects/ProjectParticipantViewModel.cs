using Laboras22.Models.Projects;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectParticipantViewModel : ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>
    {
        public StudentViewModel Student { get; private set; }
        public RatingViewModel Rating { get; private set; }
        public GradeViewModel Grade { get; private set; }
        public int? GradeValue { get { return Grade != null ? (int?)Grade.Value : null; } }
        public int? RatingValue { get { return Rating != null ? (int?)Rating.Value : null; } }
        public string RatingComment { get { return Rating != null ? Rating.Comment : null; } }
        protected override async Task RefreshFields()
        {
            Student = await StudentViewModel.Get(model.StudentId);
            Grade = (await GradeViewModel.Where(g => g.ParticipantId == model.Id)).SingleOrDefault(null);
            Rating = (await RatingViewModel.Where(r => r.ParticipantId == model.Id)).SingleOrDefault(null);
        }
    }
}
