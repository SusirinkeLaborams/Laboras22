using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Laboras22.Views.Pages.Assignments
{
    public partial class AssignmentListPage : PageBase
    {
        private AssignmentListViewModel m_Assignments;

        public AssignmentListPage(MainWindow parentWindow, bool onlyOwnAssignments) :
            base(parentWindow)
        {
            InitializeComponent();

            DataContext = m_Assignments = new AssignmentListViewModel(onlyOwnAssignments, window.Session);
            m_CreateNewAssignmentButton.Visibility = (window.Session.UserType == SessionViewModel.UserTypeEnum.Lecturer) 
                ? System.Windows.Visibility.Visible
                : System.Windows.Visibility.Collapsed;
        }

        private void CreateNewAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            window.PushPage(new AssignmentModificationPage(window));
        }

        public override async void OnDisplay()
        {
            await m_Assignments.LoadAssignments();
        }

        private void Assignment_Click(object sender, MouseButtonEventArgs e)
        {
            var assignment = (sender as ListView).SelectedItem as AssignmentViewModel;
            if (assignment != null)
            {
                window.PushPage(new AssignmentDetailsPage(window, assignment));
            }
        }
    }
}
