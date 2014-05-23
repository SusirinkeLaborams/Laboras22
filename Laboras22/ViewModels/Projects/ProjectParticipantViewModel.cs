using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectParticipantViewModel : ViewModelBase<ProjectParticipant, ProjectParticipantViewModel>
    {
        public int Project { get { return model.Project; } set { model.Project = value; } }
        public int Student { get { return model.Student; } set { model.Student = value; } }
        public RatingViewModel Rating { set; get; }
        public GradeViewModel Grade { set; get; }
        public int? GradeValue { get { return Grade != null ? (int?)Grade.Value : null; } }
        public int? RatingValue { get { return Rating != null ? (int?)Rating.Value : null; } }
        public string RatingComment { get { return Rating != null ? Rating.Comment : null; } }
        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
