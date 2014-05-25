using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectCreationViewModel : NotifyPropertyChangedBase
    {
        private ProjectViewModel model;
        private IEnumerable<UniversityViewModel> universities;
        protected ProjectCreationViewModel(ProjectViewModel model)
        {
            this.model = model;
        }
        public IEnumerable<UniversityViewModel> Universities 
        {
            get
            {
                return universities;
            }
            private set
            {
                universities = value;
                OnPropertyChanged();
            }
        }
        private UniversityViewModel university;
        public UniversityViewModel University
        {
            get
            {
                return university;
            }
            set
            {
                university = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<FacultyViewModel> faculties;
        public IEnumerable<FacultyViewModel> Faculties 
        {
            get
            {
                return faculties;
            }
            private set
            {
                faculties = value;
                OnPropertyChanged();
            }
        }
        private FacultyViewModel faculty;
        public FacultyViewModel Faculty 
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<FacultyDepartmentViewModel> departments;
        public IEnumerable<FacultyDepartmentViewModel> Departments
        {
            get
            {
                return departments;
            }
            private set
            {
                departments = value;
                OnPropertyChanged();
            }
        }
        private FacultyDepartmentViewModel department;
        public FacultyDepartmentViewModel Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<CourseViewModel> courses;
        public IEnumerable<CourseViewModel> Courses
        {
            get
            {
                return courses;
            }
            private set
            {
                courses = value;
                OnPropertyChanged();
            }
        }
        private CourseViewModel course;
        public CourseViewModel Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<AssignmentViewModel> assignments;
        public IEnumerable<AssignmentViewModel> Assignments
        {
            get
            {
                return assignments;
            }
            private set
            {
                assignments = value;
                OnPropertyChanged();
            }
        }
        public AssignmentViewModel Assignment
        {
            get
            {
                return model.Assignment;
            }
            set
            {
                model.Assignment = value;
                OnPropertyChanged();
            }
        }
        public string ProjectName
        {
            get
            {
                return model.Name;
            }
            set
            {
                model.Name = value;
                OnPropertyChanged();
            }
        }
        public async Task LoadUniversities()
        {
            Universities = await UniversityViewModel.Enumerate();
        }
        public async Task LoadFaculties()
        {
            Faculties = await FacultyViewModel.Where(x => x.UniversityId == university.Id);
        }
        public async Task LoadDepartments()
        {
            Departments = await FacultyDepartmentViewModel.Where(x => x.FacultyId == faculty.Id);
        }
        public async Task LoadCourses()
        {
            Courses = await CourseViewModel.Where(x => x.FacultyDepartmentId == department.Id);
        }
        public async Task LoadAssignments()
        {
            Assignments = await AssignmentViewModel.Where(x => x.CourseId == course.Id);
        }
        public static async Task<ProjectCreationViewModel> Create(AssignmentViewModel assignment = null, StudentViewModel student = null)
        {
            var tmp = await ProjectViewModel.Create();
            var instance = new ProjectCreationViewModel(tmp);
            if (tmp.Owner == null)
                tmp.Owner = student;
            if(assignment != null)
            {
                tmp.Assignment = assignment;
                instance.Course = assignment.Course;
                instance.Department = instance.Course.FacultyDepartment;
                instance.Faculty = instance.Department.Faculty;
                instance.University = instance.Faculty.University;
                await instance.LoadUniversities();
                await instance.LoadFaculties();
                await instance.LoadDepartments();
                await instance.LoadCourses();
                await instance.LoadAssignments();
            }
            return instance;
        }
    }
}
