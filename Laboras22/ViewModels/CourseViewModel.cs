using Laboras22.Models;
using Laboras22.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels
{
    public class CourseViewModel : ViewModelBase<Course, CourseViewModel>
    {
        public string Name { get { return model.Name; } set { model.Name = value; } }
        public int FacultyDepartmentId { get { return model.FacultyDepartmentId; } set { model.FacultyDepartmentId = value; } }
    }
}
