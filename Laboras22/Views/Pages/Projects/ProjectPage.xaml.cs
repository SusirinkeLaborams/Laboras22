using Laboras22.ViewModels.Projects;
using Laboras22.Views.Pages;
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

namespace Laboras22.Views.Pages.Projects
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectPage : PageBase
    {
        private ProjectViewModel viewModel;
        private int projectId;
        public ProjectPage(MainWindow window, int projectId) : base(window)
        {
            this.projectId = projectId;
            InitializeComponent();
        }
        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            viewModel = await ProjectViewModel.Get(projectId);
            DataContext = viewModel;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
