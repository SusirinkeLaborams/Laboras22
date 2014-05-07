using Laboras22.Classes;
using Laboras22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels
{
    public class AssignmentViewModel : ViewModelBase<Assignment, AssignmentViewModel>
    {
        public string Name { get { return model.Name; } set { model.Name = value; } }
        public int CourseId { get { return model.CourseId; } set { model.CourseId = value; } }
    }
}
