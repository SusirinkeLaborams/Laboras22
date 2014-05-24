using Laboras22.Classes;
using MahApps.Metro.Controls;

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AzureService.Connect();
            
            m_Frame.Content = new LoginPage();
        }
    }
}
