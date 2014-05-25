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
using Laboras22.ValidationRules;
using Laboras22.ViewModels.Users;

namespace Laboras22.Views.Pages.Users
{
    /// <summary>
    /// Interaction logic for UserDataModificationPage.xaml
    /// </summary>
    partial class UserDataModificationPage : PageBase
    {
        private IUserViewModel m_ViewModel;

        public UserDataModificationPage(MainWindow window, IUserViewModel user)
            : base(window)
        {
            InitializeComponent();
            m_ViewModel = user;
        }

        public override void OnDisplay()
        {
            m_Root.DataContext = m_ViewModel;
        }

        public override async void OnPop()
        {
            var student = m_ViewModel as StudentViewModel;
            if (student != null)
            {
                await student.Revert();
                return;
            }

            var lecturer = m_ViewModel as LecturerViewModel;
            if (lecturer != null)
            {
                await lecturer.Revert();
                return;
            }

            var administrator = m_ViewModel as AdministratorViewModel;
            if (administrator != null)
            {
                await administrator.Revert();
                return;
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsInputValid())
            {
                var student = m_ViewModel as StudentViewModel;
                if (student != null)
                {
                    await student.Update();
                    window.PopPage();
                }

                var lecturer = m_ViewModel as LecturerViewModel;
                if (lecturer != null)
                {
                    await lecturer.Update();
                    window.PopPage();
                }

                var administrator = m_ViewModel as AdministratorViewModel;
                if (administrator != null)
                {
                    await administrator.Update();
                    window.PopPage();
                }
            }
        }

        private bool IsInputValid()
        {
            return !Validation.GetHasError(m_FirstNameTextBox) &&
                   !Validation.GetHasError(m_LastNameTextBox) &&
                   !Validation.GetHasError(m_EmailTextBox);
        }
    }
}
