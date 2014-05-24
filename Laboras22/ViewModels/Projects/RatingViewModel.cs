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
        public int Value { get { return model.Value; } set { model.Value = value; } }
        public string Comment { get { return model.Comment; } set { model.Comment = value; } }
#pragma warning disable 1998
        protected override async Task RefreshFields()
        {
        }
#pragma warning restore 1998
    }
}
