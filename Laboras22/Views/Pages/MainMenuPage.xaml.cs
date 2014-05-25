using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages.Assignments;
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

namespace Laboras22.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : PageBase
    {
        public MainMenuPage(MainWindow window) :
            base(window)
        {
            InitializeComponent();

            AddTab(new AssignmentListPage(window, false), "All assignments");

            if (window.Session.UserType == SessionViewModel.UserTypeEnum.Lecturer)
            {
                AddTab(new AssignmentListPage(window, true), "My assignments");
            }
        }

        void AddTab(Page page, string header)
        {
            var frame = new Frame();
            var tab = new TabItem();

            frame.Content = page;
            tab.Header = header;
            tab.Content = frame;

            m_TabControl.Items.Add(tab);
        }
    }
}
