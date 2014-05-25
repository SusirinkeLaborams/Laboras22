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
using System.Windows.Shapes;
using Laboras22.ViewModels.Users;

namespace Laboras22.Views.Pages.Users
{
    /// <summary>
    /// Interaction logic for ManageUsersPage.xaml
    /// </summary>
    public partial class ManageUsersPage : PageBase
    {
        private ManageUsersViewModel m_ViewModel;
        public ManageUsersPage(MainWindow parent) : base(parent)
        {
            InitializeComponent();
            
        }

        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            m_ViewModel = new ManageUsersViewModel();
            m_Root.DataContext = m_ViewModel;
            await m_ViewModel.LoadUsers();
        }

        private async void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            (new RegisterWindow(true)).ShowDialog();
            await m_ViewModel.LoadUsers();
        }

        private void ShowStudents(object sender, RoutedEventArgs e)
        {
            m_UserList.Visibility = Visibility.Collapsed;
            m_LecturerList.Visibility = Visibility.Collapsed;
            m_AdministratorList.Visibility = Visibility.Collapsed;
            m_StudentList.Visibility = Visibility.Visible;
        }

        private void ShowAdministrators(object sender, RoutedEventArgs e)
        {
            m_StudentList.Visibility = Visibility.Collapsed;
            m_UserList.Visibility = Visibility.Collapsed;
            m_LecturerList.Visibility = Visibility.Collapsed;
            m_AdministratorList.Visibility = Visibility.Visible;
        }

        private void ShowLecturers(object sender, RoutedEventArgs e)
        {
            m_StudentList.Visibility = Visibility.Collapsed;
            m_UserList.Visibility = Visibility.Collapsed;
            m_AdministratorList.Visibility = Visibility.Collapsed;
            m_LecturerList.Visibility = Visibility.Visible;
        }

        private void ShowAll(object sender, RoutedEventArgs e)
        {
            m_StudentList.Visibility = Visibility.Collapsed;
             m_LecturerList.Visibility = Visibility.Collapsed;
            m_AdministratorList.Visibility = Visibility.Collapsed;

            m_UserList.Visibility = Visibility.Visible;
        }
    }
}
