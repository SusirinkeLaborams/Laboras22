using Laboras22.ViewModels.Projects;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages.Assignments;
using Laboras22.Views.Pages.Projects;
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
using Laboras22.Views.Pages.Users;

namespace Laboras22.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : PageBase
    {
        List<PageBase> m_TabsContents = new List<PageBase>();

        public MainMenuPage(MainWindow window) :
            base(window)
        {
            InitializeComponent();

            AddTab(new AssignmentListPage(window, false), "All assignments");
            AddTab(new ProjectList(window, new AllProjectListViewModel()), "All projects");

            switch(window.Session.UserType)
            {
                case SessionViewModel.UserTypeEnum.Administrator:
                    AddTab(new ManageUsersPage(window), "Users");
                    break;
                case SessionViewModel.UserTypeEnum.Lecturer:
                    AddTab(new AssignmentListPage(window, true), "My assignments");
                    break;
                case SessionViewModel.UserTypeEnum.Student:
                    AddTab(new ProjectList(window, new ParticipatedProjectListViewModel(window.Session.User.Id)), "My projects");
                    break;
            }
        }

        void AddTab(PageBase page, string header)
        {
            var frame = new Frame();
            var tab = new TabItem();

            frame.Content = page;
            tab.Header = header;
            tab.Content = frame;

            m_TabControl.Items.Add(tab);
            m_TabsContents.Add(page);
        }

        public override void OnDisplay()
        {
            if (m_TabControl.SelectedIndex > -1)
            {
                m_TabsContents[m_TabControl.SelectedIndex].OnDisplay();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_TabsContents[m_TabControl.SelectedIndex].OnDisplay();
        }
    }
}
