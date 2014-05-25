using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
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

namespace Laboras22.Views.Pages.Assignments
{
    /// <summary>
    /// Interaction logic for AssignmentCreationPage.xaml
    /// </summary>
    public partial class AssignmentCreationPage : PageBase
    {
        AssignmentViewModel m_ViewModel;

        public AssignmentCreationPage(MainWindow parentWindow) :
            base(parentWindow)
        {
            InitializeComponent();
        }

        protected override async void OnInitialized(EventArgs e)
        {
            var lecturerGetTask = LecturerViewModel.Get(window.Session.User.Id);
            var viewModelCreationTask = await AssignmentViewModel.Create();

            base.OnInitialized(e);

            DataContext = m_ViewModel = await viewModelCreationTask;
            var lecturer = await lecturerGetTask;

            m_ViewModel.Lecturer = lecturer;
            m_ViewModel.LoadCourses(lecturer.FacultyDepartment.Id);
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            await m_ViewModel.Insert();
            window.PopPage();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            window.PopPage();
        }

        private bool IsInputValid()
        {
            return !Validation.GetHasError(m_AssignmentNameTextBox) &&
                   !Validation.GetHasError(m_CourseComboBox) &&
                   !Validation.GetHasError(m_DifficultyTextBox);
        }
    }
}
