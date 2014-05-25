using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboras22.Views.Pages.Assignments
{
    /// <summary>
    /// Interaction logic for AssignmentDetailsPage.xaml
    /// </summary>
    partial class AssignmentDetailsPage : PageBase
    {
        internal AssignmentDetailsPage(MainWindow parentWindow, AssignmentViewModel assignment) :
            base(parentWindow)
        {
            InitializeComponent();
            DataContext = assignment;

            m_CreateProjectButton.Visibility = (window.Session.UserType == SessionViewModel.UserTypeEnum.Student)
                ? System.Windows.Visibility.Visible
                : System.Windows.Visibility.Collapsed;
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            window.PushPage(new ProjectCreationPage(window, (AssignmentViewModel)DataContext));
        }
    }
}
