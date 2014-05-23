using Laboras22.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class RatingViewModel : ViewModelBase<Rating, RatingViewModel>
    {
        public int Participant { get { return model.Participant; } set { model.Participant = value; } }
        public int Value { get { return model.Value; } set { model.Value = value; } }
        public string Comment { get { return model.Comment; } set { model.Comment = value; } }
        protected override async Task RefreshFields()
        {
            throw new NotImplementedException();
        }
    }
}
