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
    public partial class AssignmentModificationPage : PageBase
    {
        AssignmentViewModel m_ViewModel;
        bool m_CreateNewAssignment;

        internal AssignmentModificationPage(MainWindow parentWindow, AssignmentViewModel viewModel = null) :
            base(parentWindow)
        {
            m_ViewModel = viewModel;
            m_CreateNewAssignment = m_ViewModel == null;

            InitializeComponent();
        }

        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            LecturerViewModel lecturer;

            if (m_ViewModel == null)
            {
                lecturer = await LecturerViewModel.Get(window.Session.User.Id);

                m_ViewModel = await AssignmentViewModel.Create();
                m_ViewModel.Lecturer = lecturer;
            }
            else
            {
                lecturer = m_ViewModel.Lecturer;
            }            

            m_ViewModel.LoadCourses(lecturer.FacultyDepartment.Id);
            DataContext = m_ViewModel;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            if (m_CreateNewAssignment)
            {
                await m_ViewModel.Insert();
            }
            else
            {
                await m_ViewModel.Update();
            }

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
