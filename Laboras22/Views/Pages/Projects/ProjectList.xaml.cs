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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboras22.Views.Pages.Projects
{
    /// <summary>
    /// Interaction logic for ProjectList.xaml
    /// </summary>
    public partial class ProjectList : PageBase
    {
        private ProjectListViewModel viewModel;
        internal ProjectList(MainWindow window, ProjectListViewModel viewModel) : base(window)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            root.DataContext = viewModel;
        }
        private void ItemClick(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as ProjectViewModel;
            if (item != null)
            {
                window.PushPage(new ProjectPage(window, item.Id));
            }
        }
    }
}
