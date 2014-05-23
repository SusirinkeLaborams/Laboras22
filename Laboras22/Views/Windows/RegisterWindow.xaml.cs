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
using MahApps.Metro.Controls;

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : MetroWindow
    {
        private RegisterViewModel m_RegisterViewModel;
        public RegisterWindow()
        {
            InitializeComponent();
            m_RegisterViewModel = new RegisterViewModel();
            m_LayoutRoot.DataContext = m_RegisterViewModel;
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m_RegisterViewModel.Register(m_PasswordBox.Password);
        }
    }
}
