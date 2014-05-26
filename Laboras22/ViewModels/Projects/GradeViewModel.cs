using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class GradeViewModel : ViewModelBase<Grade, GradeViewModel>
    {
        public int Value { get { return model.Value; } set { model.Value = value; } }
        private ProjectParticipantViewModel participant;
        public ProjectParticipantViewModel Participant
        {
            get
            {
                return participant;
            }
            set
            {
                participant = value;
                model.ParticipantId = value.Id;
            }
        }
        public override async Task Insert()
        {
            model.ParticipantId = participant.Id;
            await base.Insert();
        }
        protected override async Task RefreshFields()
        {
            participant = await ProjectParticipantViewModel.Get(model.ParticipantId);
        }
    }
}
