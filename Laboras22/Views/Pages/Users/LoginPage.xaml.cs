﻿using System;
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
using Laboras22.Views.Pages;
using Laboras22.Views.Pages.Assignments;
using Laboras22.Views.Windows;

namespace Laboras22.Views.Pages.Users
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage
    {
        private LoginViewModel m_LoginViewModel;
        private MainWindow window;
        public LoginPage(MainWindow parent)
        {
            window = parent;
            InitializeComponent();
        }
        
        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            window.Session = null;
            m_LoginViewModel = await LoginViewModel.Create();
            m_LayoutRoot.DataContext = m_LoginViewModel;
        }
        
        private async void LoginButton_Click_1(object sender, RoutedEventArgs e)
        {
            m_LoginButton.IsEnabled = false;
            m_RegisterButton.IsEnabled = false;
            window.Session = await m_LoginViewModel.Login(m_PasswordBox.SecurePassword);
            
            if (window.Session == null)
            {
                //TODO do more stuff
                StyledMessageDialog.Show("Failed to login", "Error", MessageBoxButton.OK);
            }
            else
            {
                window.PushPage(new AssignmentListPage(window));
            }
            m_LoginButton.IsEnabled = true;
            m_RegisterButton.IsEnabled = true;
        }

        private void RegisterButton_Click_1(object sender, RoutedEventArgs e)
        {
            m_LoginButton.IsEnabled = false;
            m_RegisterButton.IsEnabled = false;
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
            m_LoginButton.IsEnabled = true;
            m_RegisterButton.IsEnabled = true;
        }
    }
}
