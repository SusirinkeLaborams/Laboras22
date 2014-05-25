using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        private void CreateNewAssignmentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            window.PushPage(new AssignmentCreationPage(window));
        }

        public override async void OnDisplay()
        {
            await m_Assignments.LoadAssignments();
        }
    }
}
