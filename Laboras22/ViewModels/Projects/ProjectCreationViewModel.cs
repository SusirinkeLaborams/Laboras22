using Laboras22.ViewModels.Assignments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels.Projects
{
    class ProjectCreationViewModel : NotifyPropertyChangedBase
    {
        private IEnumerable<UniversityViewModel> universities;
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
        public async Task LoadUniversities()
        {
            Universities = await UniversityViewModel.Enumerate();
        }
        public async Task LoadFaculties()
        {
            Faculties = await FacultyViewModel.Where(x => x.UniversityId == university.Id);
        }
    }
}
