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
        private Stack<PageBase> pages = new Stack<PageBase>();
        public MainWindow()
        {
            InitializeComponent();
            AzureService.Connect();

            PushPage(new LoginPage(this));
        }

        public void PushPage(PageBase page)
        {
            pages.Push(page);

            m_Frame.Content = page;
            page.OnDisplay();            
        }

        public void PopPage()
        {
            if(pages.Count > 1)
            {
                pages.Pop();

                var page = pages.Peek();
                m_Frame.Content = page;
                page.OnDisplay();
            }
        }

        /*protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == System.Windows.Input.Key.Back)
                PopPage();
        }*/

        internal SessionViewModel Session { get; set; }
    }
}
