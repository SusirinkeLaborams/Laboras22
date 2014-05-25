using Laboras22.Classes;
using Laboras22.ViewModels.Users;
using Laboras22.Views.Pages;
using Laboras22.Views.Pages.Projects;
using Laboras22.Views.Pages.Users;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Laboras22.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : MetroWindow
    {
        private Stack<Page> pages = new Stack<Page>();
        public MainWindow()
        {
            InitializeComponent();
            AzureService.Connect();

            PushPage(new LoginPage(this));
        }
        public void PushPage(Page page)
        {
            pages.Push(page);
            m_Frame.Content = pages.Peek();
        }
        public void PopPage()
        {
            if(pages.Count > 1)
            {
            pages.Pop();
                m_Frame.Content = pages.Peek();
            }
        }

        internal SessionViewModel Session { get; set; }
    }
}
