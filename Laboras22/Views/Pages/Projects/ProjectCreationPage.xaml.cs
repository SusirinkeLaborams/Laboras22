using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Projects;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboras22.Views.Pages.Projects
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ProjectCreationPage : PageBase
    {
        private ProjectCreationViewModel model;
        private AssignmentViewModel assignment;
        internal ProjectCreationPage(MainWindow window, AssignmentViewModel assignment = null) : base(window) 
        {
            this.assignment = assignment;
            InitializeComponent();
        }
        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            model = await ProjectCreationViewModel.Create(assignment, window.Session.User as StudentViewModel);
            root.DataContext = model;
            await model.LoadUniversities();
        }

        private async void UniversityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await model.LoadFaculties();
        }

        private async void FacultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await model.LoadDepartments();
        }

        private async void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await model.LoadCourses();
        }

        private async void CourceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await model.LoadAssignments();
        }

        private void AssignmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            window.PopPage();
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid())
                return;
            await model.ViewModel.Insert();
        }
        private bool IsValid()
        {
            return 
                !Validation.GetHasError(UniversityComboBox) &&
                !Validation.GetHasError(FacultyComboBox) &&
                !Validation.GetHasError(DepartmentComboBox) &&
                !Validation.GetHasError(CourceComboBox) &&
                !Validation.GetHasError(AssignmentComboBox) &&
                !Validation.GetHasError(ProjectNameTextBox);
        }
    }
}
