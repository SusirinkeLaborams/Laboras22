using Laboras22.Classes;
using Laboras22.Models.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Assignments
{
    public class AssignmentViewModel : ViewModelBase<Assignment, AssignmentViewModel>
    {
        #region Settable properties

        public string Name { get { return model.Name; } set { model.Name = value; } }

        public CourseViewModel Course 
        {
            get { return course; }
            set 
            {
                course = value;
                model.CourseId = course.Id;
            }
        }

        public LecturerViewModel Lecturer
        {
            get { return lecturer; }
            set
            {
                lecturer = value;
                model.LecturerId = lecturer.Id;
            }
        }

        public int Difficulty { get { return model.Difficulty; } set { model.Difficulty = value; } }

        #endregion

        #region Read-only properties

        public string CourseName { get { return Course != null ? Course.Name : null; } }
        public string LecturerName { get { return Lecturer.LastName; } }

        #endregion

        #region Fields

        private CourseViewModel course;
        private LecturerViewModel lecturer;

        #endregion

        protected override async Task RefreshFields()
        {
            course = await CourseViewModel.Get(model.CourseId);
            lecturer = await LecturerViewModel.Get(model.LecturerId);
        }
    }
}
