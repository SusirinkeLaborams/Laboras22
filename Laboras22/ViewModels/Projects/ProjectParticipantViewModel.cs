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
        public int? RatingValue;
        public string RatingComment;
        protected override async Task RefreshFields()
        {
            Student = await StudentViewModel.Get(model.Student);
            Grade = (await GradeViewModel.Where(g => g.Participant == model.Id)).SingleOrDefault(null);
            Rating = (await RatingViewModel.Where(r => r.Participant == model.Id)).SingleOrDefault(null);
            if(Rating != null)
            {
                RatingValue = Rating.Value;
                RatingComment = Rating.Comment;
            }
        }
        public static new async Task<ProjectParticipantViewModel> Create(ProjectParticipant model = null)
        {
            var created = await ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>.Create(model);
            await created.RefreshFields();
            return created;
        }
    }
}
