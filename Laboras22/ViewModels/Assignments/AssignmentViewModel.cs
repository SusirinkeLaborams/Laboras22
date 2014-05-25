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
    class AssignmentViewModel : ViewModelBase<Assignment, AssignmentViewModel>
    {
        #region Settable properties

        public string AssignmentName { get { return model.AssignmentName; } set { model.AssignmentName = value; } }
        public string Task { get { return model.Task; } set { model.Task = value; } }

        public CourseViewModel Course 
        {
            get { return m_Course; }
            set 
            {
                m_Course = value;
                model.CourseId = m_Course.Id;
            }
        }

        public LecturerViewModel Lecturer
        {
            get { return m_Lecturer; }
            set
            {
                m_Lecturer = value;
                model.LecturerId = m_Lecturer.Id;
            }
        }

        public int Difficulty { get { return model.Difficulty; } set { model.Difficulty = value; } }

        #endregion

        #region Read-only properties

        public string CourseName { get { return Course != null ? Course.Name : null; } }
        public string LecturerName { get { return Lecturer.Name; } }
        public IEnumerable<CourseViewModel> Courses { get { return m_Courses; } }

        #endregion

        #region Fields

        private CourseViewModel m_Course;
        private LecturerViewModel m_Lecturer;
        private IEnumerable<CourseViewModel> m_Courses;

        #endregion

        protected override async Task RefreshFields()
        {
            m_Course = await CourseViewModel.Get(model.CourseId);
            m_Lecturer = await LecturerViewModel.Get(model.LecturerId);
        }

        public override string ToString()
        {
            return AssignmentName;
        }

        public async void LoadCourses(int facultyDepartmentId)
        {
            m_Courses = await CourseViewModel.Where(x => x.FacultyDepartmentId == facultyDepartmentId);
            OnPropertyChanged("Courses");
        }
    }
}
