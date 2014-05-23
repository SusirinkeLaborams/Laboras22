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

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private LoginViewModel m_LoginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            m_LoginViewModel = new LoginViewModel();
            m_LayoutRoot.DataContext = m_LoginViewModel;
        }
        
        private void LoginButton_Click_1(object sender, RoutedEventArgs e)
        {
            m_LoginViewModel.Login(m_PasswordBox.Password);
        }

        private void RegisterButton_Click_1(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
