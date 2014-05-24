using Laboras22.ViewModels.Projects;
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

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        private ProjectViewModel viewModel;
        private int projectId;
        public ProjectPage(int projectId)
        {
            this.projectId = projectId;
            InitializeComponent();
        }
        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            viewModel = await ProjectViewModel.Get(projectId);
            root.DataContext = viewModel;
        }
    }
}
