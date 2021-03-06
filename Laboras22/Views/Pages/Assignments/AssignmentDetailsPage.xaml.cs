﻿using Laboras22.ViewModels.Assignments;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages.Projects;
using Laboras22.Views.Windows;
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

            m_EditAssignmentButton.Visibility = m_DeleteAssignmentButton.Visibility =
                (window.Session.UserLogin.Id == assignment.Lecturer.LoginId || window.Session.UserType == SessionViewModel.UserTypeEnum.Administrator)
                ? System.Windows.Visibility.Visible
                : System.Windows.Visibility.Collapsed;
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            window.PushPage(new ProjectCreationPage(window, (AssignmentViewModel)DataContext));
        }

        private void EditAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            window.PushPage(new AssignmentModificationPage(window, (AssignmentViewModel)DataContext));
        }

        public override void OnDisplay()
        {
            if (DataContext != null)
            {
                ((AssignmentViewModel)DataContext).NotifyAllPropertiesChanged();
            }
        }

        private async void DeleteAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            var result = StyledMessageDialog.Show("Do you really want to delete this assignment? If you proceed, all projects associated with this assignment will be deleted as well.",
                "Delete assignment", MessageBoxButton.YesNo);

            if (result.HasValue && result.Value)
            {
                var assignment = (AssignmentViewModel)DataContext;

                m_EditAssignmentButton.IsEnabled = false;
                m_DeleteAssignmentButton.IsEnabled = false;

                await assignment.Delete();
                window.PopPage();
            }
        }
    }
}
