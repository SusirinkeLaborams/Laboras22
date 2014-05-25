using Laboras22.ViewModels.Projects;
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
        public ProjectCreationPage(MainWindow window) : base(window) 
        {
            InitializeComponent();
        }
        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            model = new ProjectCreationViewModel();
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

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //dunno, lol
        }
    }
}
